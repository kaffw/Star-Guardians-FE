using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyBehaviour : MonoBehaviour
{
    CharacterManager chManager;
    SpriteRenderer sr;

    void Start()
    {
        chManager = GameObject.FindObjectOfType<CharacterManager>();    
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(chManager.isNight)
        {
            sr.color = new Color(0.0039f, 0.0667f, 0.1255f, 1f);
        }
        else
        {
            sr.color = new Color(0.498f, 0.831f, 0.973f, 1f);
        }
    }
}
