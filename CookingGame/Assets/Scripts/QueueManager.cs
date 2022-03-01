using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public static QueueManager instance;
    [SerializeField] public List<Transform> Checkpoints;
    [SerializeField] GameObject ClientPrefab;

    public Vector3 CounterOccupied = Vector3.zero;
    public GameObject[] ClientAtSpot = new GameObject[3];


    public bool allClientsHaveBeenServed = false;
    public int TotalNumberofClients = 30;
    public int spawnedClient = 0;
    public int servedClient = 0;
    [SerializeField] int QueueCapacity = 5;
    public List<ClientQueuer> queue = new List<ClientQueuer>();

    [SerializeField] public bool autoSpawn = false;
    [SerializeField] public bool autoLeave = false;
    float startEndCheckDelay = 0;
    float counterSpawn = 0;
    [Space] [SerializeField] float spawnDelay = 2f;
    [SerializeField] [Range(0, 1)] float clientDoneChance = 0.001f;

    bool rowHasBeenFilled = false;

    public RecipeDisplay[] Displays = new RecipeDisplay[3];

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        foreach (RecipeDisplay rd in FindObjectsOfType<RecipeDisplay>())
        {
            Displays[rd.displayNumber] = rd;
        }

        TotalNumberofClients = (PlayerPrefs.GetInt("ClientNumber")== 0)? 3 : PlayerPrefs.GetInt("ClientNumber");
    }

    public void ClientExit(int index)
    {
        if ( CounterOccupied[index - 1] != 0)
        {
            ClientQueuer exiting = ClientAtSpot[index - 1].GetComponent<ClientQueuer>();
            if (exiting.atPlace)
            {
                queue.RemoveAt(exiting.orderInQueue-1);
                int j = 1;
                foreach (ClientQueuer cq in queue) { cq.orderInQueue = j; j++; }


                CounterOccupied[exiting.spot] = 0;
                ClientAtSpot[exiting.spot] = null;

                //Instantiate(ParticlesInventory.instance.starSuccess, exiting.transform.position, Quaternion.identity);
                Displays[exiting.spot].ExitDisplay();

                exiting.isDone = true;
                //Destroy(exiting.gameObject);
            }
        }
    }

    public void SpawnClient()
    {
        if (queue.Count <= QueueCapacity && spawnedClient <TotalNumberofClients )
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

            spawnedClient++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        allClientsHaveBeenServed = (servedClient == TotalNumberofClients);

        if (autoSpawn)
        {
            counterSpawn += Time.deltaTime;
            if (counterSpawn >= spawnDelay)
            {
                SpawnClient();
                counterSpawn = 0;
            }

        }

        if (autoLeave)
        {

            int sumCounterOcc = (int)(CounterOccupied.x + CounterOccupied.y + CounterOccupied.z);
            rowHasBeenFilled = (sumCounterOcc == 3);

            if (Random.value < clientDoneChance && rowHasBeenFilled)
            {

                int a = Random.Range(1, 4);
                //print(a);
                ClientExit(a);


            }
        }

    }
}