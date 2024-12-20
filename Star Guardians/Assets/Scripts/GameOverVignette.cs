using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverVignette : MonoBehaviour
{
    Image fade;
    float fadeVal;
    Color changedColor;

    void Start()
    {
        fade = GetComponent<Image>();
        fadeVal = 0f;
    }

    void Update()
    {
        fadeVal += Time.deltaTime / 3f;
        changedColor = new Color(0f, 0f, 0f, fadeVal);    
        fade.color = changedColor;
    }
}
