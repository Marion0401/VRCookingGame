using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public enum Aliments
    {
        SALADE,
        TOMATE,
        PAIN
    }

    public class SpawnAliment : MonoBehaviour
    {
        public int cutalimnb;
        private GameObject alimentdebase;
        private GameObject decoupe;
        public Aliments aliment;
        public ParticleSystem particulecoup;
        public Collider MaindCollider1;
        public Collider MaindCollider2;
        public Collider MaindCollider3;
        public int nbcoup = 3;
        

        private void Start()
        {
            switch (aliment)
            {
                case (Aliments.TOMATE):
                {
                    alimentdebase = Instantiate(Resources.Load("Tomato", typeof(GameObject)), transform) as GameObject;
                    //alimentdebase= Resources.Load<GameObject>("=Tomato");
                    decoupe = Resources.Load<GameObject>("Tranch_Tomate");
                    Rigidbody rb = alimentdebase.GetComponent<Rigidbody>() as Rigidbody;
                    var aaa = alimentdebase.GetComponent<DecoupageAliment>();
                    aaa.MaindCollider1 = MaindCollider1;
                    aaa.MaindCollider2 = MaindCollider2;
                    aaa.MaindCollider3 = MaindCollider3;
                    aaa.decoupe = decoupe;
                    aaa.nbalimentdecoupe = cutalimnb;
                    aaa.nbcoup = nbcoup;
                    //rb.useGravity = false;
                    break;
                }
                case (Aliments.SALADE):
                {
                    alimentdebase = Instantiate(Resources.Load("Lettuce", typeof(GameObject)), transform) as GameObject;
                    //alimentdebase= Resources.Load<GameObject>("=Sla");
                    decoupe = Resources.Load<GameObject>("CutSalad");
                    Rigidbody rb = alimentdebase.GetComponent<Rigidbody>() as Rigidbody;
                    var aaa = alimentdebase.GetComponent<DecoupageAliment>();
                    aaa.MaindCollider1 = MaindCollider1;
                    aaa.MaindCollider2 = MaindCollider2;
                    aaa.MaindCollider3 = MaindCollider3;
                    aaa.decoupe = decoupe;
                    aaa.nbalimentdecoupe = cutalimnb;
                    //rb.useGravity = false;
                    break;
                }
                case (Aliments.PAIN):
                {

                    alimentdebase = Instantiate(Resources.Load("BreadRoll", typeof(GameObject)), transform) as GameObject;
                    //alimentdebase= Resources.Load<GameObject>("=Sla");
                    decoupe = Resources.Load<GameObject>("Tranche_Pain");
                    Rigidbody rb = alimentdebase.GetComponent<Rigidbody>() as Rigidbody;
                    var aaa = alimentdebase.GetComponent<DecoupageAliment>();
                    aaa.MaindCollider1 = MaindCollider1;
                    aaa.MaindCollider2 = MaindCollider2;
                    aaa.MaindCollider3 = MaindCollider3;
                    aaa.decoupe = decoupe;
                    aaa.nbalimentdecoupe = cutalimnb;
                    //rb.useGravity = false;
                    break;
                }
            }
            //Instantiate(alimentdebase);


        }

    }
}
