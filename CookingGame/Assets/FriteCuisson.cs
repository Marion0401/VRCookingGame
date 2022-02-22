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
        if (other.name == "RECT_Pot")
        {
            Debug.Log("enter");
            isInPoele = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RECT_Pot")
        {
            Debug.Log("exit");
            isInPoele = false;
        }
    }

}
