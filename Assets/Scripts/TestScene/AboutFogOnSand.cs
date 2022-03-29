using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutFogOnSand : MonoBehaviour
{
    private bool m_IsOnTiresFogArea = false;
    private void OnTriggerEnter(Collider other)
    {
       if( other.GetComponent<VehicleMove>())
       m_IsOnTiresFogArea=true;
          
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnTiresFogArea = false;

    }
    private void OnGUI()
    {
        if (m_IsOnTiresFogArea)
        {
            GUI.Box(new Rect(100, 100, 250, 200), "And also it foogs by \n particle system and object pooling ");
        }
            
    }
}
