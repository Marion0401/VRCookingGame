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
            
            gameObject.GetComponent<MeshRenderer>().material = MaterialCuit;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Contenace>())
        {
            //Debug.Log("enter");
            isInPoele = true;
            //this.transform.parent = poele.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Contenace>() )
        {
            //Debug.Log("exit");
            isInPoele = false;
            //transform.parent = null;
        }
    }

}
