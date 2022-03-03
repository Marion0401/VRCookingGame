using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planche : MonoBehaviour
{

   

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DecoupageAliment>())
        {
            other.GetComponent<DecoupageAliment>().isInPlanche = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DecoupageAliment>())
        {
            other.GetComponent<DecoupageAliment>().isInPlanche = false;
        }
    }

}
