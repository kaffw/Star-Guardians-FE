using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject upperBodyGameOver, humanGameOver;
    
    private bool called = false;

    void Update()
    {
        if(!called && CharacterManager.hp == 0)
        {
            UpperBodyGameOver();
            called = true;
        }

        if(!called && Input.GetKey(KeyCode.V))
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
