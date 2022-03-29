using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaHA : MonoBehaviour
{
 


    private bool m_IsOnHaHa = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnHaHa = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnHaHa = false;

    }
    private void OnGUI()
    {
        if (m_IsOnHaHa)
        {
            GUI.Box(new Rect(100, 100, 250, 200), "HA-HA!!! \n look at your car");
        }

    }


}
