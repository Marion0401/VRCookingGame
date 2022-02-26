using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderQueueMarker : MonoBehaviour
{
    QueueManager manager;
    public int index;
    public bool taken = false;

    private void Awake()
    {
        manager = GetComponentInParent<QueueManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("client");
        taken = true;
        manager.CounterOccupied[index - 1] = 1;
        manager.ClientAtSpot[index - 1] = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        taken = false;
        manager.CounterOccupied[index - 1] = 0;
        manager.ClientAtSpot[index - 1] = null;
    }
}
