using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection_frite : MonoBehaviour
{
    [SerializeField] private GameObject frite;
    [SerializeField] private Color colorok;
    [SerializeField] private Color colornotok;
    private int frites_contenu = 0;
    [SerializeField] private GameObject objet_qui_change_de_couleur;
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == frite.tag)
        {
            frites_contenu += 1;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == frite.tag)
        {
            frites_contenu -= 1;
        }
    }

    private void Update()
    {
        if (frites_contenu > 4)
        {
            Debug.Log("il y a au moins 5 frites");
        }
    }
}
