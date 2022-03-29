using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3Person : MonoBehaviour
{
    public Transform target;
    float mouseX;
    float mouseY;
    public float sensivity = 10.0f;
    void Start()
    {
        mouseX = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
     
        mouseX += Input.GetAxis("Mouse X") * sensivity; 
        mouseY -= Input.GetAxis("Mouse Y") * sensivity;
        mouseY = Mathf.Clamp(mouseY,-45,45);
        transform.localEulerAngles = new Vector3 (mouseY, mouseX, 0);
    }
}
