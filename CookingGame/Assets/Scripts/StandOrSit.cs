using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandOrSit : MonoBehaviour
{
    void Start()
    {
        string player = PlayerPrefs.GetString("position");
        if (player == "Sitting")
        {
            gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.9f, 0.7f, 0.9f);
        }
    }


}
