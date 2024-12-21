using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuCanvasManager : MonoBehaviour
{
    [Header("Splash Art")]
    public Image splashArt;
    public Sprite[] splashArtSprite;
    private int splashIndex;

    public float timer;

    //-------------------------------//
    [Header("Canvases")]
    public GameObject mainMenuCanvas;
    public GameObject optionsCanvas;
    public GameObject creditsCanvas;

    public static bool skipHowToPlay = false;

    void Start()
    {
        timer = 0f;
        splashIndex = 0;
    }

    void Update()
    {
        UpdateSplash();
    }

    public void PlayGame()
    {
        Debug.Log("Plays Game");
        if(!skipHowToPlay)
        {
            skipHowToPlay = true;
            SceneManager.LoadScene("HowToPlay");
        }
        else SceneManager.LoadScene("World1");
    }

    public void EnterOptions()
    {
        optionsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void EnterCredits()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        creditsCanvas.SetActive(true);

    }

    public void BackToMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void UpdateSplash()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            timer = 0f;
            splashIndex = (splashIndex == 0) ? 1 : 0;
            StartCoroutine(UpdateSplashSprite());
        }
    }

    IEnumerator UpdateSplashSprite()
    {
        for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime)
        {
            Color color = splashArt.color;
            color.a = alpha;
            splashArt.color = color;
            yield return null;
        }

        splashArt.sprite = splashArtSprite[splashIndex];

        for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime)
        {
            Color color = splashArt.color;
            color.a = alpha;
            splashArt.color = color;
            yield return null;
        }
    }
}
