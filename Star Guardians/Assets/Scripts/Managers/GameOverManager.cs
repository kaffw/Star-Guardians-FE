using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject upperBodyGameOver, humanGameOver;
    
    private bool called = false;
    
    public DayAndNightTaskManager dntManager;
    public TaskListPopManager tlpManager;
    void Awake()
    {
        dntManager = GameObject.FindObjectOfType<DayAndNightTaskManager>();
        tlpManager = GameObject.FindObjectOfType<TaskListPopManager>();
    }

    void Update()
    {
        if(!called && (CharacterManager.hp == 0 || Input.GetKey(KeyCode.B)))
        {
            UpperBodyGameOver();
            called = true;
        }

        if(!called && Input.GetKey(KeyCode.V))
        {
            HumanGameOver();
            called = true;
        }

        if(dntManager.dayCount == 5 && dntManager.nightCount == 5 && tlpManager.nightTaskCleared) //&& night task cleared
        {
            HumanGameOver();
            called = true;
        }
    }

    public void UpperBodyGameOver()
    {
        upperBodyGameOver.SetActive(true);
    }

    public void HumanGameOver()
    {
        humanGameOver.SetActive(true);
    }

    public void YES()
    {
        SceneManager.LoadScene("World1");
    }

    public void NO()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
