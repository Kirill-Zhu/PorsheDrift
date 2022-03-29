using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierRotation : MonoBehaviour
{
    public WheelCollider wheelCol;
    Vector3 pos;
    Quaternion rot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wheelCol.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;   
        
    }
}
