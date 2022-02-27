using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriteCreator : MonoBehaviour
{
    public GameObject frite;
    private GameObject frite_clone;
    public float compteur;
    public float time_spawn = 3;
    public int nb_frite_par_spawn = 10;
    public int max_frites_dans_saladier = 30;
    public Contenace Contenace;
    public GameObject poele;
    void Start()
    {
        
    }

    void Update()
    {
        Spawner();
    }

    public void Spawner()
    {
        if (compteur> time_spawn && Contenace.frites_contenu< max_frites_dans_saladier)
        {
            compteur = 0;
            for (int i = 0; i < nb_frite_par_spawn; i++)
            {
                frite_clone = Instantiate(frite, transform.position, transform.rotation * Quaternion.Euler(-59, 28, 0f));
                frite_clone.transform.SetParent(poele.transform, false);
                frite_clone.transform.localScale = new Vector3((float)(0.15201 / 30), (float)(0.15201 / 30), (float)(0.374687 / 16));
                frite_clone.transform.position = gameObject.transform.position;
            }
        }
        else
        {
            compteur = compteur + Time.deltaTime;
        }
    }
}
