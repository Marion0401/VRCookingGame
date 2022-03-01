using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenace : MonoBehaviour
{
    public int frites_contenu = 0;
    public int steak_contenu = 0;

    public Ingredient cookType = Ingredient.None;

    Vector3 StartPosition;
    Quaternion StartRotation;
    public Transform NourritureParent;

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
        if (other.GetComponent<FriteCuisson>())
        {
            frites_contenu++;
        }
        else if (other.GetComponent<Cuisson>())
        {
            steak_contenu++;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FriteCuisson>())
        {
            frites_contenu--;
        }
        else if (other.GetComponent<Cuisson>())
        {
            steak_contenu--;
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
