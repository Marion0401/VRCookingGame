using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection_frite : MonoBehaviour
{
    [SerializeField] private GameObject frite;
    private int frites_contenu = 0;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject detachParent;
    [SerializeField] private IngredientType IngredientType;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == frite.tag)
        {
            frites_contenu += 1;
            Debug.Log(frites_contenu);
            other.transform.SetParent(parent.transform);
            VerifNbFrite();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == frite.tag)
        {
            frites_contenu -= 1;
            Debug.Log(frites_contenu);
            other.transform.SetParent(detachParent.transform);
            VerifNbFrite();
        }
    }

    private void VerifNbFrite()
    {
        if (frites_contenu > 4)
        {
            Debug.Log("il y a au moins 5 frites");
            IngredientType.typeOfIngredient = EnumIngredient.Frites;
        }
        else
        {
            Debug.Log("il y a moins de 5 frites");
            IngredientType.typeOfIngredient = EnumIngredient.None;
        }
    }
}