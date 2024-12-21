using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGMManager : MonoBehaviour
{
    AudioManager aManager;

    void Start()
    {
        aManager = GameObject.FindObjectOfType<AudioManager>();    
        aManager.PlayMainMenuBGM();
    }
}
