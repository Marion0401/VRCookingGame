using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTakenObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    private bool hasMoved;
    private bool atPlace=true; 
    private Vector3 place;
    public Transform parent;
    private bool hasbeengrabed = false;
    private bool hasbeengrabedOneTime = false;
    // Start is called before the first frame update
    void Start()
    {
        place = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (atPlace)
        {
            if (transform.position != place)
            {
                hasMoved = true;
                atPlace = false;
            }
        }
        
        if (hasMoved)
        {
            Instantiate(objectToSpawn, place, Quaternion.identity, parent);
            hasMoved = false;
        }

        if (gameObject.transform.parent == null)
        {
            hasbeengrabed = true;
        }
       

        if (hasbeengrabed && gameObject.transform.parent!=null && !hasbeengrabedOneTime)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            hasbeengrabedOneTime = true;
        }

    }
}
