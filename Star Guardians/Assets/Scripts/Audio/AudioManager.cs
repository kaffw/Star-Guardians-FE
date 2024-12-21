using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource musicSource;
    AudioSource sfxSource;
    Scene currScene;

    public AudioClip[] bgm;
    public AudioClip[] sfx;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        /*musicSource.clip = bgm[0];
        musicSource.loop = true;
        musicSource.Play();*/
        PlayMainMenuBGM();
    }

    void Update()
    {
        musicSource.volume = AudioVolumeManager.bgmGlobalVolume;
        sfxSource.volume = AudioVolumeManager.sfxGlobalVolume;
    }

    public void PlaySFX(int sfxIndex)
    {
        sfxSource.clip = sfx[sfxIndex];
        sfxSource.Play();
    }

    public void PlayMorningBGM()
    {
        musicSource.clip = bgm[0];
        musicSource.loop = true;
        musicSource.Play();
    }
    
    public void PlayNightBGM()
    {
        musicSource.clip = bgm[1];
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayMainMenuBGM()
    {
        musicSource.clip = bgm[2];
        musicSource.loop = true;
        musicSource.Play();
    }
}