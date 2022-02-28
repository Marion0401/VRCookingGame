using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenace : MonoBehaviour
{
    public int frites_contenu = 0;
    public int steak_contenu = 0;

    Vector3 StartPosition;
    Quaternion StartRotation;

    void Start()
    {
        StartPosition = transform.position;
        StartRotation = transform.rotation;
    }

    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "frite(Clone)")
        {
            frites_contenu = frites_contenu + 1;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "frite(Clone)")
        {
            frites_contenu = frites_contenu - 1;
        }
    }

    public void ResetPostion()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        transform.position = StartPosition;
        transform.rotation = StartRotation;
    }
}
