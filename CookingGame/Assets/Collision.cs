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

        public float nbalimentdecoupe;
        public GameObject decoupe;
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
            
                for (int i = -1; i <=nbalimentdecoupe-2; i++)
                {
                    Instantiate(decoupe, transform.position+new Vector3(0,1.5f*i,0), 
                        transform.rotation*Quaternion.Euler(new Vector3(0,3*i,0)));
                }
            
                Destroy(this.gameObject);
            }
        }
    }
}
