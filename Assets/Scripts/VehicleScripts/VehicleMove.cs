using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleMove : MonoBehaviour
{
    //DriftCount components
    public float speed;
    Rigidbody rb;
    public  GameObject spoiler;
    public List<WheelCollider> forwardWheels;
    public List<WheelCollider> backWheels;
    public float horsePower = 10.0f;
    public float breakForce = 10.0f;
    private float vertInput;
    private float horInput;
    Vector3 _spoilerAngle = new Vector3(3,0,0);
    public Vector3 vehicleCenterOfMass;
   
    //For DriftCounting() Method
    public float driftCount;
    public float angle;
    public float backAngle;
    public bool isGrounded;

   
  
    //TimeScaler(): Toogles Time.timeScale betwen 1f and 0.5f 
    private int timeScaleToogle;
   
    // 
    FixedJoint joint;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

 
    void Update()
    {
        var velocity = transform.InverseTransformDirection(rb.velocity);
        speed = velocity.z;
        
        vertInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
        
        
        SpoilerMove(spoiler, _spoilerAngle, 35);
       
        GetComponent<Rigidbody>().centerOfMass = vehicleCenterOfMass;
       
        DrifCounting(rb.velocity, transform.forward);
        
        TimeScaler();
    }

    private void FixedUpdate()
    {
        WheelParametersDenpendencyOfGround();
        WheelCollidersMove(horsePower);
    }
    protected virtual void WheelCollidersMove(float _speed)
    {
        foreach(WheelCollider forwardWheel in forwardWheels)
        {
            forwardWheel.steerAngle = horInput * 40;
            //forwardWheel.motorTorque = vertInput *_speed *Time.deltaTime;
            
        }
    foreach (WheelCollider backWheel in backWheels)
        {
            backWheel.motorTorque = vertInput*_speed *Time.deltaTime;
           
        }
    
    if(Input.GetKey(KeyCode.Space))
        {
            foreach(WheelCollider backWheel in backWheels)
            {
                backWheel.brakeTorque = breakForce;
            }
        }
        else
        {
            foreach(WheelCollider backlWheel in backWheels)
            {
                backlWheel.brakeTorque = 0;
            }
        }
    }

    protected virtual void SpoilerMove(GameObject _spoiler, Vector3 spoilerAngle, float rbVelocityToUpTheSpoiler)
    {
        if (_spoiler != null)
        {
           
            if (rb.velocity.magnitude > rbVelocityToUpTheSpoiler)
            {

                _spoiler.transform.localEulerAngles = Vector3.Slerp(_spoiler.transform.localEulerAngles, spoilerAngle, 0.01f);

            }
            else
            {
                _spoiler.transform.localEulerAngles = Vector3.Slerp(_spoiler.transform.localEulerAngles, new Vector3(0, 0, 0), 0.01f);
            }
        }
    }

    protected void DrifCounting(Vector3 velocityDirecion, Vector3 directionOfTrunk)
    {
        angle = Vector3.Angle(velocityDirecion, directionOfTrunk);
        backAngle = Vector3.Angle(velocityDirecion, -transform.forward);

        
        
        if (angle > 10 && speed > 0.2f&&backAngle>2 && isGrounded)
        {
            driftCount += (angle * rb.velocity.magnitude)*Time.deltaTime;
        } 
        
        
    }
   private void TimeScaler()
    {
    

        if (Input.GetKeyDown(KeyCode.R))
        {
            timeScaleToogle++;
        }
        switch (timeScaleToogle)
        {
            case 0:
                Time.timeScale = 1f;
                break;
            case 1:
                Time.timeScale = 0.5f;
                break;
            case 2:
                timeScaleToogle = 0;
                break;

            default:
                break;
        }
       Time.fixedDeltaTime = 0.02f *Time.timeScale;


    }


   
   
    private void OnTriggerEnter(Collider other)
    {
      // Instantiate a door lock to close opened door
        if (other.CompareTag("Dor") && other.attachedRigidbody.velocity.magnitude - rb.velocity.magnitude >0.5f)
        {
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = other.attachedRigidbody;
            joint.breakForce = 3000f;
        }
    }
   
    
private void WheelParametersDenpendencyOfGround()
    {
        WheelHit hit;
        
        RaycastHit rHit;
        if(Physics.Raycast(transform.position + new Vector3(0,0.5f,0), -transform.up, out rHit,0.7f))
        {
            if (rHit.collider.tag == "Road")
            {
                rb.drag = 0.05f;
                Debug.Log("On Road");
            }
            else if (rHit.collider.tag == "Sand")
            {
                rb.drag = 0.3f;
                Debug.Log("On sand");
            }
            
        }
        else
        {
            rb.drag=0.05f;
        }
        
        foreach (WheelCollider backWheel in backWheels)
        {
        
            
            backWheel.GetGroundHit(out hit);
            WheelFrictionCurve fFriction = backWheel.forwardFriction;



            if (hit.collider.tag == "Sand")
            {
                fFriction.extremumSlip = 0.1f;
                fFriction.extremumValue = 2;
                fFriction.asymptoteSlip = 1f;
                fFriction.asymptoteValue = 2;
                fFriction.stiffness = 1f;

            }
            if (hit.collider.tag == "Road")
            {
                fFriction.extremumSlip = 0.4f;
                fFriction.extremumValue = 0.94f;
                fFriction.asymptoteSlip = 0.8f;
                fFriction.asymptoteValue = 0.8f;
                fFriction.stiffness = 1.5f;

            }

            backWheel.forwardFriction = fFriction;


            WheelFrictionCurve sFriction = backWheel.sidewaysFriction;

            if (hit.collider.tag == "Sand")
            {
                sFriction.extremumSlip = 0.4f;
                sFriction.extremumValue = 2;
                sFriction.asymptoteSlip = 0;
                sFriction.asymptoteValue = 2;
                sFriction.stiffness = 1f;
            }
            if (hit.collider.tag == "Road")
            {
                sFriction.extremumSlip = 0.2f;
                sFriction.extremumValue = 0.9f;
                sFriction.asymptoteSlip = 0.35f;
                sFriction.asymptoteValue = 0.75f;
                sFriction.stiffness = 1f;

            }
            backWheel.sidewaysFriction = sFriction;







        }
        foreach (WheelCollider forawadrWheel in forwardWheels)
        {
            forawadrWheel.GetGroundHit(out hit);
            WheelFrictionCurve fFriction = forawadrWheel.forwardFriction;
            
            
            
            if(hit.collider.tag== "Sand")
            {
                fFriction.extremumSlip = 0.1f;
                fFriction.extremumValue = 2;
                fFriction.asymptoteSlip = 1f;
                fFriction.asymptoteValue = 2;
                fFriction.stiffness = 1f;


            }
            if (hit.collider.tag == "Road")
            {
                fFriction.extremumSlip = 0.4f;
                fFriction.extremumValue = 0.9f;
                fFriction.asymptoteSlip = 0.8f;
                fFriction.asymptoteValue = 0.5f;
                fFriction.stiffness = 1.5f;

            }

            forawadrWheel.forwardFriction = fFriction;

           
            WheelFrictionCurve sFriction = forawadrWheel.sidewaysFriction;
           
            if(hit.collider.tag =="Sand")
            {
                sFriction.extremumSlip = 0.4f;
                sFriction.extremumValue = 2;
                sFriction.asymptoteSlip= 0;
                sFriction.asymptoteValue = 2;
                sFriction.stiffness =1f;
                
            }
            if (hit.collider.tag == "Road")
            {
                sFriction.extremumSlip = 0.2f;
                sFriction.extremumValue = 1f;
                sFriction.asymptoteSlip = 0.35f;
                sFriction.asymptoteValue = 0.75f;
                sFriction.stiffness = 1.2f;

            }
            forawadrWheel.sidewaysFriction = sFriction;


           
        }

        if (rHit.collider == true)
        {
            isGrounded = true;
            
        }
        else
        {
            isGrounded = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(rb.worldCenterOfMass, rb.velocity);
    }

}
   
