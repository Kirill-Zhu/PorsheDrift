using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClipping : MonoBehaviour
{
    public Transform target;
    public float  maxDistance = 9f;
    public LayerMask obstacles;
   
    

    void Update()
    {
      RaycastHit hit;
        float distance =Vector3.Distance(transform.position, target.position);
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, maxDistance, obstacles))
        {
            transform.position = hit.point;
        }
  
        else if (distance<maxDistance && !Physics.Raycast(transform.position, -transform.forward,0.1f, obstacles))
        {
         transform.position -= transform.forward * 0.05f;
        }
            
        
    }
}
