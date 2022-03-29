using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleLights : MonoBehaviour
{
    private bool frontTourcehsIsOn = true;
    public Material frontEmission;
    public GameObject[] frontLights;
   
    public Material backlEmission;
    public GameObject[] backLights;

    

    // Update is called once per frame
    void Update()
    {
        FrontLight();
        BackLights();
    }
private void FrontLight()
    {
       if(!frontTourcehsIsOn&&Input.GetKeyDown(KeyCode.T))
       {

            frontEmission.EnableKeyword("_EMISSION");
            foreach(GameObject light in frontLights)
            {
                light.SetActive(true);
            }
            frontTourcehsIsOn = true;
        }
      else  if(frontTourcehsIsOn&&Input.GetKeyDown(KeyCode.T))
        {
           
            frontEmission.DisableKeyword("_EMISSION");
            foreach (GameObject light in frontLights)
            {
                light.SetActive(false);
            }
            frontTourcehsIsOn = false;  
        }
    
    }

    private void BackLights()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            backlEmission.EnableKeyword("_EMISSION");
            foreach(GameObject light in backLights)
            {
               light.SetActive(true);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            backlEmission.DisableKeyword("_EMISSION");
            foreach (GameObject light in backLights)
            {
                light.SetActive(false);
            }
        }
    }
}

