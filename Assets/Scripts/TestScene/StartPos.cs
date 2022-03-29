using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour
{
 
    

    private bool m_IsOnStartPos = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnStartPos = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnStartPos = false;

    }
    private void OnGUI()
    {
        if (m_IsOnStartPos)
        {
            GUI.Box(new Rect(100, 100, 250, 200), "use WASD to move \n 'T' to toogle lights");
        }

    }
}

