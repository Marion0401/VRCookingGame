using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [SerializeField] public List<Transform> Checkpoints;
    [SerializeField] GameObject ClientPrefab;

    public Vector3 CounterOccupied = Vector3.zero;

    bool QueueFull = false;
    public List<ClientQueuer> queue = new List<ClientQueuer>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ClientExit()
    {
        ClientQueuer exiting = queue[0];
        queue.RemoveAt(0);
        foreach (ClientQueuer cq in queue) cq.orderInQueue--;
    }

    public void SpawnClient()
    {
        GameObject go = Instantiate(ClientPrefab, new Vector3(Checkpoints[Checkpoints.Count-1].position.x, 1, Checkpoints[Checkpoints.Count-1].position.y), Quaternion.identity);
        ClientQueuer cq = go.GetComponent<ClientQueuer>();
        queue.Add(cq);
        cq.orderInQueue = queue.Count;
        cq.passedCheckpoints = Checkpoints.Count;
        cq.manager = this;
        cq.destination = Checkpoints[Checkpoints.Count - 1].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
