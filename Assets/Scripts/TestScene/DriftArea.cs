using TMPro;
using UnityEngine;

public class DriftArea : MonoBehaviour
{
    private bool m_IsOnDriftArea = false;
    public GameObject player;
    public TextMeshProUGUI drifScore;

    private void Update()
    {
       if(m_IsOnDriftArea)
        {

            drifScore.text = "Drift Score:" + (int)player.GetComponent<VehicleMove>().driftCount;

        }
        else
        {
            drifScore.text = "";
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnDriftArea = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VehicleMove>())
            m_IsOnDriftArea = false;
    }
    private void OnGUI()
    {
        if (m_IsOnDriftArea) 
        GUI.Box(new Rect(100, 100, 250, 200), "Use Spase to do some DRIFT!");

    }
}
