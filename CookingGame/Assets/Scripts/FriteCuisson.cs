using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriteCuisson : MonoBehaviour
{
    public Material MaterialCru;
    public Material MaterialCuit;
    public float compteur =0f;
    public float temps_cuisson = 5;

    public bool isInPoele = false;
    public GameObject poele;

    
    public Transform poelePos;

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = MaterialCru;
    }

    void Update()
    {
        Cuisson();
    }

    public void Cuisson()
    {
        if (isInPoele)
        {
            compteur = compteur + Time.deltaTime;
            
            Instantiate(ParticlesInventory.instance.fryingBubbles, poelePos.transform.position, Quaternion.Euler(-90, 0, 0));
        }

        if (compteur > temps_cuisson)
        {
            
            gameObject.GetComponent<MeshRenderer>().material = MaterialCuit;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Contenace>())
        {
            if(other.GetComponent<Contenace>().cookType == Ingredient.Fries || other.GetComponent<Contenace>().cookType == Ingredient.FriesBox)
            {
                //Debug.Log("enter");
                if (other.GetComponent<Contenace>().cookType == Ingredient.Fries) isInPoele = true;
                poelePos = other.transform;
                transform.parent = poelePos.transform;

                
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Contenace>() )
        {
            if (other.GetComponent<Contenace>().cookType == Ingredient.Fries || other.GetComponent<Contenace>().cookType == Ingredient.FriesBox)
            {
                //Debug.Log("exit");
                if (other.GetComponent<Contenace>().cookType == Ingredient.Fries) isInPoele = false;
                transform.parent = other.GetComponent<Contenace>().NourritureParent;
                poelePos = null;
            }
        }
    }

}
