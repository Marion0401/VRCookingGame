using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientQueuer : MonoBehaviour
{
    public int passedCheckpoints = 0;
    public int orderInQueue = 0;

    public QueueManager manager;

    public Vector3 destination;
    public bool possibleMove = true;

    public bool atPlace = false;
    public bool selectedPlace = false;

    public int spot = 0;

    public float speed=1;

    [SerializeField] Vector3 directionToLookAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.GetComponent<ClientQueuer>())
        {
            
            if (collision.gameObject.GetComponent<ClientQueuer>().orderInQueue == orderInQueue-1)
            {
                print(collision.name);
                possibleMove = false;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<ClientQueuer>())
        {
            if (collision.gameObject.GetComponent<ClientQueuer>().orderInQueue == orderInQueue - 1);
            {
                possibleMove = true;
            }
        }
    }
    */

    float DistanceToNext()
    {
        if (orderInQueue >3)
        {
            float dist = (float)((Mathf.Pow(transform.position.x - manager.queue[orderInQueue - 2].transform.position.x, 2) + Mathf.Pow(transform.position.z - manager.queue[orderInQueue - 2].transform.position.z, 2)) / 1.41421);
            return dist;
        }
        else
        {
            return 1000f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Animator>().SetFloat("MoveSpeed",0.5f);
        possibleMove = (DistanceToNext() > 1.5f);
        if (!possibleMove)
        {
            GetComponentInChildren<Animator>().SetFloat("MoveSpeed",0f);
        }
        //print(DistanceToNext().ToString() + " " + orderInQueue.ToString());
        //destination.y = transform.localScale.y / 2;
        if (passedCheckpoints<manager.Checkpoints.Count - 3 && possibleMove)
        {
            Vector3 distToDest = (transform.position - destination);

            if (distToDest.magnitude < 0.5 )
            {
                passedCheckpoints++;
                destination = manager.Checkpoints[passedCheckpoints].position;
                destination.y = 1;
            }
            else
            {
                transform.LookAt(new Vector3(destination.x, 1, destination.z));
                transform.position -= speed*(distToDest.normalized * Time.deltaTime);
            }
        }
        else if (orderInQueue<=3 && passedCheckpoints >= manager.Checkpoints.Count - 3)
        {
            if(!selectedPlace && !atPlace)
            {
                GetComponentInChildren<Animator>().SetFloat("MoveSpeed",0f);
                for (int i = 0; i < 3; i++)
                {
                    if (manager.CounterOccupied[i] == 0)
                    {
                        spot = i;
                        manager.CounterOccupied[i] = 1;
                        manager.ClientAtSpot[i] = this.gameObject;
                        destination = manager.Checkpoints[manager.Checkpoints.Count-i-1].position;
                        destination.y = 1;
                        selectedPlace = true;
                        break;
                    }
                }
            }
            else if (!atPlace)
            {
                Vector3 distToDest = (transform.position - destination);

                transform.LookAt(new Vector3(destination.x, 1, destination.z));
                transform.position -= speed * (distToDest.normalized *Time.deltaTime);

                if (distToDest.magnitude < 0.5 && !atPlace)
                {
                    manager.Displays[spot].StartDIsplay();

                    atPlace = true;
                    transform.LookAt(transform.position + directionToLookAt);
                    GetComponentInChildren<Animator>().SetFloat("MoveSpeed",0f);
                }
            }

            if (atPlace)
            {
                GetComponentInChildren<Animator>().SetFloat("MoveSpeed",0f);
            }



            /*
            if(manager.CounterOccupied[orderInQueue-1] == 0)
            {
                Vector3 distToDest = (transform.position - destination);

                if (distToDest.magnitude < 0.5 && possibleMove)
                {
                    if(passedCheckpoints < manager.Checkpoints.Count-1)
                    passedCheckpoints++;

                    destination = manager.Checkpoints[passedCheckpoints].position;
                    destination.y = 1;
                }
                else
                {
                    transform.LookAt(new Vector3(destination.x, 1, destination.z));
                    transform.position -= (distToDest.normalized / 100);
                }
            }
            */
        }
        else
        {
            GetComponentInChildren<Animator>().SetFloat("MoveSpeed",0f);
        }
    }
}
