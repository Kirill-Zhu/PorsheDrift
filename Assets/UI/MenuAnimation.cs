using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    Animator animator;
    Camera cam;
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
       
        
        if (Physics.Raycast(ray, out hit))
        {
           
                 hit.collider.GetComponent<Animator>().SetBool("FontScaler", true);




        }
        else
        {
            animator.SetBool("FontScaler", false);
        }
    }
}
