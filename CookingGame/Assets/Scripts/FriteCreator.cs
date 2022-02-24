using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriteCreator : MonoBehaviour
{
    public GameObject frite;
    public float compteur;
    public float time_spawn = 3;
    public int nb_frite_par_spawn = 10;
    public int max_frites_dans_saladier = 30;
    public Contenace Contenace;
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
                Instantiate(frite, transform.position, transform.rotation * Quaternion.Euler(-59, 28, 0f));
            }
        }
        else
        {
            compteur = compteur + Time.deltaTime;
        }
    }
}
