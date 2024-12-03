using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasManager : MonoBehaviour
{
    public Image splashArt;
    public Sprite[] splashArtSprite;
    private int splashIndex;

    public float timer;
    void Start()
    {
        timer = 0f;
        splashIndex = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 60)
        {
            timer = 0f;
            splashIndex = (splashIndex == 0) ? 1 : 0;
            StartCoroutine(UpdateSplash());
        }
    }

    IEnumerator UpdateSplash()
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
