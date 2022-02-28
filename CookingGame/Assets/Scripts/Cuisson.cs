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
        //Debug.Log(other.name);
        if (other.name == "poele2")
        {
            //Debug.Log("enter");
            isInPoele = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log(other.name);
        if (other.name == "poele2")
        {
            //Debug.Log("exit");
            isInPoele = false;
        }
    }

}
