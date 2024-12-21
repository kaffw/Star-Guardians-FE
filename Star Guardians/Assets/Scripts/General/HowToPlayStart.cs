using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayStart : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("World1");
    }
}
