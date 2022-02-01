using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientQueuer : MonoBehaviour
{
    public int passedCheckpoints = -1;
    public int orderInQueue = 0;

    public QueueManager manager;

    public Vector3 destination;
    bool possibleMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ClientQueuer>())
        {
            if (collision.gameObject.GetComponent<ClientQueuer>() == manager.queue[orderInQueue-1])
            {
                possibleMove = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<ClientQueuer>())
        {
            if (collision.gameObject.GetComponent<ClientQueuer>() == manager.queue[orderInQueue - 1])
            {
                possibleMove = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        destination.z = transform.localScale.y / 2;
        if (passedCheckpoints>3)
        {
            Vector3 distToDest = (transform.position - destination);

            if (distToDest.magnitude < 0.5 && possibleMove)
            {
                passedCheckpoints--;
                destination = manager.Checkpoints[manager.Checkpoints.Count - passedCheckpoints].position;
            }
            else
            {
                transform.LookAt(destination);
                transform.position -= (distToDest.normalized / 100);
            }
        }



    }
}
