using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandParticleSystemScrips : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] int arrayValue;
    private ParticleSystem[] prefabArray;
       

    private void Start()
    {
       prefabArray = new ParticleSystem[arrayValue];


        for (int i = 0; i < arrayValue; i++)
        {
            prefabArray[i] = Instantiate(prefab.GetComponent<ParticleSystem>());
            prefabArray[i].transform.parent = transform;
            prefabArray[i].gameObject.SetActive(false);
            prefabArray[i].transform.localScale = Vector3.one;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        for(int i = 0; i < arrayValue;i++)
        {
            if (!prefabArray[i].gameObject.activeInHierarchy)
            {
                prefabArray[i].transform.position = collision.contacts[0].point;

                prefabArray[i].gameObject.SetActive(true);
                return;
                
            }
            
        }




    }
 


}
