using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriteCuisson : MonoBehaviour
{
    public Material MaterialCru;
    public Material MaterialCuit;
    public float compteur;
    public float temps_cuisson = 3;

    public bool isInPoele = false;
    public GameObject poele;


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
        }

        if (compteur > temps_cuisson)
        {
            Debug.Log("Frite cuite");
            gameObject.GetComponent<MeshRenderer>().material = MaterialCuit;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == poele.GetComponent<Collider>())
        {
            Debug.Log("enter");
            isInPoele = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == poele.GetComponent<Collider>())
        {
            Debug.Log("exit");
            isInPoele = false;
        }
    }

}
