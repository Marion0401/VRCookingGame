using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuisson : MonoBehaviour
{
    public GameObject poele;
    public bool isInPoele = false;
    public float compteur = 0;
    public float temps_cuisson = 3;
    public GameObject steak_cuit;
    private GameObject IngredientHolder;

    void Start()
    {
        IngredientHolder = GameObject.Find("Nourriture");
    }

    void Update()
    {
        if (isInPoele)
        {
            compteur = compteur + Time.deltaTime;
            Instantiate(ParticlesInventory.instance.fryingBubbles, poele.transform.position, Quaternion.Euler(-90, 0, 0));
        }

        if (compteur > temps_cuisson)
        {
            //Debug.Log("poele2");
            Instantiate(steak_cuit, transform.position, transform.rotation, IngredientHolder.transform);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Contenace>())
        {
            if (other.GetComponent<Contenace>().cookType == Ingredient.Steak)
            {
                //Debug.Log("enter");
                isInPoele = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<Contenace>())
        {
            if (other.GetComponent<Contenace>().cookType == Ingredient.Steak)
            {
                //Debug.Log("exit");
                isInPoele = false;
            }
        }
    }

}
