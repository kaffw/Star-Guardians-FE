using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseCanvas;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        PauseCanvas.SetActive(Time.timeScale == 0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
