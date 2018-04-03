using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseUI;
    private bool paused = false;
    private AudioSource buttonClick;

    void Start()
    {
        pauseUI.SetActive(false);
        buttonClick = GetComponents<AudioSource>()[1];
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        buttonClick.Play();
        paused = false;
    }

    public void Restart()
    {
        buttonClick.Play();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        buttonClick.Play();
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void PauseGame(){
        buttonClick.Play();
        paused = true;
    }

    public bool isPaused(){
        return paused;
    }
}
