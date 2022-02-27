using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public class Collision :MonoBehaviour
    {
        [SerializeField] private AudioSource sondecoupe;
        [SerializeField] private Collider planche;
        public float nbalimentdecoupe;
        public GameObject decoupe;
        public Collider MaindCollider;
        public int nbcoup=3;
        public GameObject parent;
        public bool isInPlanche=false;
        private Transform StartPosition;

        public void Awake()
        {
            parent = GameObject.Find("Nourriture");
            StartPosition = gameObject.transform;
        }
        private void OnTriggerEnter(Collider other)
        {
        
            if (other == MaindCollider)
            {
                Debug.Log("coup dans la salade");
                sondecoupe.Play();
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
                gameObject.transform.position = StartPosition.position;
                gameObject.transform.rotation = StartPosition.rotation;

            }
        }

        private void OnTriggerEnter(Collider2D other)
        {
            Debug.LogError(other.name);
            if (other==planche)
            {
                Debug.LogError("GoodInPLanvhe");
                isInPlanche = true;
            }   
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == planche)
            {
                isInPlanche = false;
            }
        }

    }
}
