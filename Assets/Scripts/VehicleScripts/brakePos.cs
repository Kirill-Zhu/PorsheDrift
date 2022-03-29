using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brakePos : MonoBehaviour
{
  public WheelCollider tire;
    Vector3 pos;
    Quaternion rot;
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        tire.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, tire.steerAngle,transform.localEulerAngles.z);
    }
}
