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
        
        public float nbalimentdecoupe;
        public GameObject decoupe;
        public Collider MaindCollider;
        public int nbcoup=3;
        public GameObject parent;

        public void Awake()
        {
            parent = GameObject.Find("Nourriture");
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
            if (nbcoup == 0)
            {
                Debug.Log("Salade");
            
                for (int i = 0; i <=nbalimentdecoupe-1; i++)
                {
                    
                    Instantiate(decoupe, transform.position+new Vector3(0,1.5f*i,0), 
                        transform.rotation*Quaternion.Euler(new Vector3(0,3*i,0)), parent.transform);
                }
                
                Destroy(this.gameObject);
            }
        }
    }
}
