using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObjectInRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DecoupageAliment>())
        {
            other.GetComponent<DecoupageAliment>().ResetPostion();
        }
        if (other.GetComponent<Contenace>())
        {
            other.GetComponent<Contenace>().ResetPostion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DecoupageAliment>())
        {
            other.GetComponent<DecoupageAliment>().ResetPostion();
        }
        if (other.GetComponent<Contenace>())
        {
            other.GetComponent<Contenace>().ResetPostion();
        }
    }
}
