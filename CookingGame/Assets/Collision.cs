using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public class Collision
    {
        {
        private GameObject alimentdebase;
        private GameObject decoupe;
        
        public ParticleSystem particulecoup;
        public Collider MaindCollider;
        public int nbcoup = 3;
        private void OnTriggerEnter(Collider other)
        {
        
            if (other == MaindCollider)
            {
                Debug.Log("coup dans la salade");
            
                nbcoup--;
            }
        }

        private void Update()
        {
            if (nbcoup == 0)
            {
                Debug.Log("Salade");
            
                for (int i = -1; i <= 2; i++)
                {
                    Instantiate(decoupe, transform.position+new Vector3(0,1.5f*i,0), 
                        transform.rotation*Quaternion.Euler(new Vector3(0,3*i,0)));
                }
            
                Destroy(alimentdebase);
            }
        }
    }
}