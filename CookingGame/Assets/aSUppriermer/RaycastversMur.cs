using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastversMur : MonoBehaviour
{
    
    
    private float yamn=0f;
    private float pitch = 0f;
    private float sensi = 6f;
    
    private Transform playerTransform;
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = transform;
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 currentPosition = playerTransform.position;
        //Vector3 force = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //force *= speed;
        //gameObject.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
        Vector3 deltaPosition = (
                       playerTransform.right * Input.GetAxis("Horizontal")
                      + playerTransform.forward * Input.GetAxis("Vertical")
                   ) * speed;
        //deltaPosition.y = 0f;
        playerTransform.position = currentPosition + deltaPosition;
        
        yamn += Input.GetAxis("Mouse X")*sensi;
        pitch -= Input.GetAxis("Mouse Y")*sensi;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.eulerAngles = new Vector3(pitch, yamn, 0f);

        
    }
}
