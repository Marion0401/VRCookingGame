using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public enum Aliments {SALADE,TOMATE,PAIN}

public class ColissionSalade : MonoBehaviour
{
    private GameObject alimentdebase;
    private GameObject decoupe;
    public Aliments aliment;
    public ParticleSystem particulecoup;
    public Collider MaindCollider;
    public int nbcoup = 3;
    

    private void Start()
    {
        switch (aliment)
        {
            case(Aliments.TOMATE):
            {
                alimentdebase = Instantiate(Resources.Load("Tomato", typeof(GameObject))) as GameObject;
                //alimentdebase= Resources.Load<GameObject>("=Tomato");
                decoupe = Resources.Load<GameObject>("Tranche_Tomate");
                Rigidbody rb = alimentdebase.AddComponent<Rigidbody>() as Rigidbody;
                var aaa = alimentdebase.AddComponent<ColissionSalade>();
                aaa.MaindCollider = MaindCollider;
                rb.useGravity = false;
                break;
            }
            case(Aliments.SALADE):
            {
                alimentdebase = Instantiate(Resources.Load("Sla", typeof(GameObject))) as GameObject;
                //alimentdebase= Resources.Load<GameObject>("=Sla");
                decoupe=Resources.Load<GameObject>("FeuilleSalade");
                
                break;
            }
            case(Aliments.PAIN):
            {
                
                break;
            }
        }
        //Instantiate(alimentdebase);

        
    }

}
