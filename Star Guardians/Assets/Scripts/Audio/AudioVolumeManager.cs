using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioVolumeManager : MonoBehaviour
{
    public static float bgmGlobalVolume;
    public Slider bgmSlider;
    public AudioVolumeReceiver bgmGameSceneVolume;
    
    public static float sfxGlobalVolume;
    public Slider sfxSlider;

    public static bool volumeInitialized = false;
    
    Scene currScene;

    void Awake()
    {
        if (!volumeInitialized)
        {
            volumeInitialized = true;
            bgmGlobalVolume = 1f;
            sfxGlobalVolume = 1f;
        }
    }

    void Update()
    {
        currScene = SceneManager.GetActiveScene();

        if (currScene.buildIndex == 0)
        {
            bgmGlobalVolume = bgmSlider.value;
            sfxGlobalVolume = sfxSlider.value;
        }
    }
}