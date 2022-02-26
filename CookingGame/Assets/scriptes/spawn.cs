using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private GameObject lancienobjet;
    [SerializeField] private GameObject lenouvelobjet;
    [SerializeField] private Vector3 lendroitoucaspawn;

    private void Start()
    {
        lendroitoucaspawn = transform.position;
        Instantiate(lenouvelobjet, lendroitoucaspawn, Quaternion.identity);
    }

    private void Update()
    {
        if (lenouvelobjet.transform.position != lendroitoucaspawn)
        {
            Debug.Log("hey");
            lenouvelobjet = lancienobjet;
            Instantiate(lenouvelobjet, lendroitoucaspawn, Quaternion.identity);
        }
    }
}
