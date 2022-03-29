using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandSystem : MonoBehaviour
{
    private bool m_IsOnSandTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
       if(other.GetComponent<VehicleMove>() != null)
        m_IsOnSandTrigger=true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VehicleMove>() != null)
            m_IsOnSandTrigger=false;
    }
    private void OnGUI()
    {
        if (m_IsOnSandTrigger)
        {
            GUI.Box(new Rect(100, 100, 250, 200), "Look how the vehicle \n behaviour changes on sand");
        }
     
       
    }
}
