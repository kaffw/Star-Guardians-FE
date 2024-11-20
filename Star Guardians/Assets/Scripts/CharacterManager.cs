using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    //profile image for active body
    public Sprite[] profileSprite;
    public Image profileImage;

    public bool isNight = false; // get val from Day/Night Manager (currently on redo progress)

    //Camera and Movement Manager
    public MonoBehaviour upperBodyMovement, lowerBodyMovement;
    public GameObject upperBodyCam, lowerBodyCam, humanBodyCam;

    public enum BodyState { Human, Manananggal };
    public BodyState state;
    public bool isDetached = false; //for manananggal state
    void Update()
    {
        //enable if night

        if (Input.GetKeyDown(KeyCode.M)) isNight = false; //temp day/ night setter
        else if(Input.GetKeyDown(KeyCode.N)) isNight = true;

        if (isNight)
        {
            state = BodyState.Manananggal;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UpperBodyMode();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                LowerBodyMode();
            }
        }
        else
        {
            state = BodyState.Human;
            humanBodyCam.SetActive(true);
        }

        //Debug.Log(state);
    }

    void UpperBodyMode()
    {
        //enable movement for manananggal, disable lower body movement
        profileImage.sprite = profileSprite[0];
        upperBodyMovement.enabled = true;
        lowerBodyMovement.enabled = false;

        upperBodyCam.SetActive(true);
        lowerBodyCam.SetActive(false);
        humanBodyCam.SetActive(false);
    }

    void LowerBodyMode()
    {
        //enable movement for lower body, disable movement for manananggal
        profileImage.sprite = profileSprite[1];
        lowerBodyMovement.enabled = true;
        upperBodyMovement.enabled = false;

        upperBodyCam.SetActive(false);
        lowerBodyCam.SetActive(true);
        humanBodyCam.SetActive(false);
    }

    public void AttachBody()
    {
        //Check if mUB is within mLB, keybind, call AttachBody.
    }

    public void DetachBody()
    {
        //Check if mUB is within mLB, keybind, call DetachBody.
    }
}
/*
Terms
h       :   Human
mUB     :   Manananggal Upper Body
mLB     :   Manananggal Lower Body
 */
