using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public class DecoupageAliment :MonoBehaviour
    {
        //[SerializeField] private AudioSource sondecoupe;
        //[SerializeField] private GameObject planche;
        public float nbalimentdecoupe;
        public GameObject decoupe;
        public Collider MaindCollider;
        public int nbcoup=3;
        public GameObject parent;
        public bool isInPlanche=false;

        private Vector3 StartPosition;
        private Quaternion StartRotation;
        private int coupsDebut;

        public void Awake()
        {
            parent = GameObject.Find("Nourriture");
        }

        public void Start()
        {
            StartPosition = transform.position;
            StartRotation = transform.rotation;
            coupsDebut = nbcoup;
        }

        private void OnTriggerEnter(Collider other)
        {
        
            if (other == MaindCollider && isInPlanche)
            {
                Debug.Log("coup dans la salade");
                //sondecoupe.Play();
                nbcoup--;
            }
        }

        private void Update()
        {
            if (nbcoup <= 0 && isInPlanche)
            {
                //Debug.Log("Salade");
            
                for (int i = 0; i <=nbalimentdecoupe-1; i++)
                {
                    
                    Instantiate(decoupe, transform.position+new Vector3(0,1.5f*i,0), 
                        transform.rotation*Quaternion.Euler(new Vector3(0,3*i,0)), parent.transform);
                }

                //Destroy(this.gameObject);
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                transform.position = StartPosition;
                transform.rotation = StartRotation;
                
                nbcoup = coupsDebut;
                isInPlanche = false;
            }
        }

        

    }
}
