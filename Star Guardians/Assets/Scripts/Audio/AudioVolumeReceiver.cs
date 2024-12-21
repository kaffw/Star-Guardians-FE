using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeReceiver : MonoBehaviour
{
    public float bgmGameLoopVolume;
    public float sfxGameLoopVolume;

    public Slider bgmGameSlider;
    public Slider sfxGameSlider;

    void Start()
    {
        bgmGameSlider.value = AudioVolumeManager.bgmGlobalVolume;// bgmGameLoopVolume;
        sfxGameSlider.value = AudioVolumeManager.sfxGlobalVolume;
    }

    void Update()
    {
        AudioVolumeManager.bgmGlobalVolume = bgmGameSlider.value;
        AudioVolumeManager.sfxGlobalVolume = sfxGameSlider.value;
    }
}