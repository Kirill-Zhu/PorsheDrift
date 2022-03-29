using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAreaScript : MonoBehaviour
{
    public float power = 1000f;
    public float count;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * power *Time.deltaTime, ForceMode.Impulse);
        other.gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
        Renderer[] objs = other.gameObject.GetComponentsInChildren<Renderer>();
        count = objs.Length;

        
    }

    


}
