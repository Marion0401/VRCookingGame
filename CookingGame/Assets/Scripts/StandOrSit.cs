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
            gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }


}
