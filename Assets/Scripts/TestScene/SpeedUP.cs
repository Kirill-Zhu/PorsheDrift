using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUP : MonoBehaviour
{
 


    private bool m_IsOnSpeedUPArea = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnSpeedUPArea = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnSpeedUPArea = false;

    }
    private void OnGUI()
    {
        if (m_IsOnSpeedUPArea)
        {
            GUI.Box(new Rect(100, 100, 250, 200), "   SPEED UP! \n Drive As fast as you can!!! ");
        }

    }


}
