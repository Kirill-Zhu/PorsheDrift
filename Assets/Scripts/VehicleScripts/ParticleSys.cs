using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys : MonoBehaviour
{
   [SerializeField] ParticleSystem[] smoke;
    WheelCollider[] backWheels;
    VehicleMove player;
    void Start()
    {
        player = GetComponent<VehicleMove>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(ParticleSystem smoke in smoke)
        {
            if( player.angle >10 && player.speed >0.2 && player.backAngle >2 && player.isGrounded)
            {
                var emission = smoke.emission;
                emission.rateOverDistance = player.speed;
            }
            else
            {
                var emission = smoke.emission;
                emission.rateOverDistance = 0f;
            }
        if(Input.GetKey(KeyCode.Space) && player.isGrounded)
            {
                var emission = smoke.emission;
                emission.rateOverDistance = player.speed;
            }
        
        }
    }
}
