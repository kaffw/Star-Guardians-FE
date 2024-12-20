using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject upperBodyGameOver, lowerBodyGameOver;
    
    private bool called = false;

    void Update()
    {
        if(!called && CharacterManager.hp == 0)
        {
            UpperBodyGameOver();
            called = true;
        }

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.L))
        {
            LowerBodyGameOver();
        }
    }

    public void UpperBodyGameOver()
    {
        upperBodyGameOver.SetActive(true);
    }

    public void LowerBodyGameOver()
    {
        lowerBodyGameOver.SetActive(true);
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
