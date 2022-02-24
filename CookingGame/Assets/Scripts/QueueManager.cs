using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [SerializeField] public List<Transform> Checkpoints;
    [SerializeField] GameObject ClientPrefab;

    public Vector3 CounterOccupied = Vector3.zero;
    public GameObject[] ClientAtSpot = new GameObject[3];

    [SerializeField] int QueueCapacity = 5;
    public List<ClientQueuer> queue = new List<ClientQueuer>();

    [SerializeField] public bool autoSpawn = false;
    [SerializeField] public bool autoLeave = false;

    float counterSpawn = 0;
    [Space] [SerializeField] float spawnDelay = 2f;
    [SerializeField] [Range(0, 1)] float clientDoneChance = 0.001f;

    bool rowHasBeenFilled = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ClientExit(int index)
    {
        if (index <= queue.Count && CounterOccupied[index-1]!=0)
        {
            ClientQueuer exiting = ClientAtSpot[index-1].GetComponent<ClientQueuer>();
            queue.RemoveAt(index - 1);
            foreach (ClientQueuer cq in queue) { if (cq.orderInQueue > index) cq.orderInQueue--; }


            CounterOccupied[exiting.spot] = 0;
            ClientAtSpot[exiting.spot] = null;

            Destroy(exiting.gameObject);
        }
    }

    public void SpawnClient()
    {
        if (queue.Count <= QueueCapacity)
        {
            //print(Checkpoints[Checkpoints.Count - 1].position.x.ToString() + " " + Checkpoints[Checkpoints.Count - 1].position.z.ToString());
            GameObject go = Instantiate(ClientPrefab, new Vector3(Checkpoints[0].position.x, 1, Checkpoints[0].position.z), Quaternion.identity);
            ClientQueuer cq = go.GetComponent<ClientQueuer>();
            queue.Add(cq);
            cq.orderInQueue = queue.Count;
            //cq.passedCheckpoints = Checkpoints.Count;
            cq.manager = this;
            cq.destination = Checkpoints[0].position;
            cq.destination.y = 1;
            //print(go.transform.position.x.ToString() + " " + go.transform.position.z.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (autoSpawn)
        {
            counterSpawn += Time.deltaTime;
            if (counterSpawn >= spawnDelay)
            {
                SpawnClient();
                counterSpawn = 0;
            }

        }

        if(autoLeave)
        { 

            int sumCounterOcc = (int)(CounterOccupied.x + CounterOccupied.y + CounterOccupied.z);
            rowHasBeenFilled = (sumCounterOcc == 3);

            if (Random.value < clientDoneChance && rowHasBeenFilled)
            {

                int a = Random.Range(1, 4);
                print(a);
                ClientExit(a);


            }
        }
        
    }
}
