using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float baseCounter = 0;
    public float tenthSeconds = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int hours = 0;

    bool counting = false;

    [SerializeField] Text timerText;
    [SerializeField] Image bottomScreen;
    [SerializeField] Text bottomText;
    int clientNumber;

    [SerializeField] GameObject exitSceneCube;
    [SerializeField] GameObject exitGameCube;

    bool done = false;

    void ResetTimer()
    {
        seconds = 0;
        minutes = 0;
        hours = 0;
        tenthSeconds = 0;
        baseCounter = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        bottomText.gameObject.SetActive(false);
        bottomScreen.color = new Color(150 / 255, 150 / 255, 150 / 255);
    }

    public void BackToStartScene()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Tick()
    {
        baseCounter += Time.deltaTime;

        if(baseCounter >= 0.1f) { baseCounter = 0; tenthSeconds += 0.1f; }
        if(tenthSeconds >= 1) { tenthSeconds = 0; seconds++; }
        if(seconds >= 60) { seconds = 0; minutes++; }
        if(minutes >= 60) { minutes = 0; hours++; }

        string time = "";
        time += (hours<10)? ("0" + hours.ToString()) : hours.ToString();
        time += " : ";
        time += (minutes < 10) ? ("0" + minutes.ToString()) : minutes.ToString();
        time += " : ";
        time += (seconds < 10) ? ("0" + seconds.ToString()) : seconds.ToString();

        timerText.text = time;
    }
    // Update is called once per frame
    void Update()
    {
        if (QueueManager.instance.queue.Count >= 0 && !counting)
        {
            counting = true;
            clientNumber = QueueManager.instance.TotalNumberofClients;
            bottomText.text = "Served all " + clientNumber.ToString() + " clients!";
        }

        if(QueueManager.instance.allClientsHaveBeenServed && !done)
        {
            done = true;
            bottomScreen.color = new Color(1, 1, 1);
            bottomText.gameObject.SetActive(true);
        }

        if (counting && !done) Tick();

        if (exitSceneCube.transform.parent != this.transform) BackToStartScene();
        if (exitGameCube.transform.parent != this.transform) ExitGame();
    }
}
