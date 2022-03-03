using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartHakimAsuppr : MonoBehaviour
{
    public bool toggle = false;


    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void OnClickedPlay()
    {
        if (toggle)
        {
            PlayerPrefs.SetString("position", "Assis");

        }
        else
        {
            PlayerPrefs.SetString("position", "Debout");

        }
        SceneManager.LoadScene("TeoScene", LoadSceneMode.Single);
    }

    public void OnToggleClicked()
    {
        toggle = !toggle;
    }

}
