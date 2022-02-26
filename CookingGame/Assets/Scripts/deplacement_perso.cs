using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement_perso : MonoBehaviour
{
    [SerializeField] private float yawn = 0f;
    [SerializeField] private float pitch = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 deltaPosition = transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * 25f + transform.forward * Input.GetAxis("Vertical") 
            * Time.deltaTime * 25f ;
        deltaPosition.y = 0f;
        

        transform.position += deltaPosition;
        
        yawn += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        
        transform.eulerAngles = new Vector3(0f,yawn , pitch); 
    }
}