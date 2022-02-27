using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chrono : MonoBehaviour
{
    float startChrono;
    float endChrono;
    bool variableCome;
    public GameObject canvasEnd;
    public Text textChrono;
    // Start is called before the first frame update
    void Start()
    {
    float startChrono = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (variableCome)
        {
            endChrono = Time.time;
            string displayChrono=GiveChrono(startChrono, endChrono);
            canvasEnd.SetActive(true);
            textChrono.text = displayChrono;
        }

    }
    string GiveChrono(float start, float end)
    {
        float difference = end - start;
        double hours=Math.Floor(difference/3600f);
        float seconds = difference % 3600;
        float minutes=seconds/60;
        seconds=seconds%60;
        string chrono = hours.ToString() + ":" + seconds.ToString() + ":" + seconds.ToString();
        return chrono;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("environnement", LoadSceneMode.Additive);
    }
}
