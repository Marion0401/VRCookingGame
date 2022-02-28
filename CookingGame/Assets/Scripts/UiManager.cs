using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject Startt;
    public GameObject Settings;
    public GameObject BackButton;
    public GameObject Credits;

    [Header("Toggle Settings)")]
    public bool toggle_bool;
    public GameObject toggle;

    void Start()
    {
        Startt.SetActive(true);
        Settings.SetActive(false);
        BackButton.SetActive(false);
        Credits.SetActive(false);

        
        toggle_bool = false;
        OnToggleClicked();
    }


    public void OnClickedPlay()
    {
        if (toggle_bool)
        {
            PlayerPrefs.SetString("position", "Sitting");

        }
        else
        {
            PlayerPrefs.SetString("position", "Upright");

        }
        SceneManager.LoadScene("TeoScene", LoadSceneMode.Single);
    }

    public void OnSettingsClicked()
    {
        Startt.SetActive(false);
        Settings.SetActive(true);
        BackButton.SetActive(true);

    }

    public void OnBackButtonClicked()
    {
        Startt.SetActive(true);
        Settings.SetActive(false);
        BackButton.SetActive(false);
        Credits.SetActive(false);
    }

    public void OnCreditClicked()
    {
        Startt.SetActive(false);
        Credits.SetActive(true);
        BackButton.SetActive(true);
    }


    public void OnToggleClicked()
    {
        toggle_bool = !toggle_bool;
        if (toggle_bool)
        {
            toggle.GetComponent<Text>().text = "Sitting";
        }
        else
        {
            toggle.GetComponent<Text>().text = "Upright";
        }
    }
}
