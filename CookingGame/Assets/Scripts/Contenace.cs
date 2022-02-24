using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenace : MonoBehaviour
{
    public int frites_contenu = 0;
    public int steak_contenu = 0;

    void Start()
    {
        
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
}
