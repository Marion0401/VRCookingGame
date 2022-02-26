using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject Startt;
    public GameObject Settings;
    public GameObject BackButton;
    public GameObject Credits;

    void Start()
    {
        Startt.SetActive(true);
        Settings.SetActive(false);
        BackButton.SetActive(false);
        Credits.SetActive(false);
    }


    public void OnPlayClicked()
    {
        Debug.Log("play");
        SceneManager.LoadScene("environnement", LoadSceneMode.Single);
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

}
