using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Sprite[] bodySprite;
    public bool isNight = false;
    public Image profileImage;

    public MonoBehaviour upperBodyMovement, lowerBodyMovement;
    public GameObject upperBodyCam, lowerBodyCam;

    void Update()
    {
        //enable if night

        if (Input.GetKeyDown(KeyCode.M)) isNight = false;
        else if(Input.GetKeyDown(KeyCode.N)) isNight = true;

        if(isNight)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                //enable movement for manananggal, disable lower body movement
                profileImage.sprite = bodySprite[0];
                upperBodyMovement.enabled = true;
                lowerBodyMovement.enabled = false;

                upperBodyCam.SetActive(true);
                lowerBodyCam.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                //enable movement for lower body, disable movement for manananggal
                profileImage.sprite = bodySprite[1];
                lowerBodyMovement.enabled = true;
                upperBodyMovement.enabled = false;

                upperBodyCam.SetActive(false);
                lowerBodyCam.SetActive(true);
            }
        }
        
    }
}
