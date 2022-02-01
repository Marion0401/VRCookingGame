using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ColissionSalade : MonoBehaviour
{
    public Collider MaindCollider;
    public int nbcoup = 3;
    public GameObject FeuilleSalade;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other == MaindCollider)
        {
            Debug.Log("enter");
            nbcoup--;
        }
    }

    private void Update()
    {
        if (nbcoup == 0)
        {
            Debug.Log("Salade");

            for (int i = -1; i <= 2; i++)
            {
                Instantiate(FeuilleSalade, transform.position+new Vector3(0,1.5f*i,0), 
                    transform.rotation*Quaternion.Euler(new Vector3(0,3*i,0)));
            }

            Destroy(gameObject);
        }
    }
}
