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

    public GameObject humanGO;
    public GameObject manananggalUpperGO;
    public GameObject manananggalLowerGO;
    Vector3 spawnPos;

    void Update()
    {
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
    }

    public void UpperBodyMode()
    {
        //enable movement for manananggal, disable lower body movement
        profileImage.sprite = profileSprite[1];
        upperBodyMovement.enabled = true;
        lowerBodyMovement.enabled = false;

        upperBodyCam.SetActive(true);
        lowerBodyCam.SetActive(false);
        humanBodyCam.SetActive(false);
    }

    void LowerBodyMode()
    {
        //enable movement for lower body, disable movement for manananggal
        profileImage.sprite = profileSprite[2];
        lowerBodyMovement.enabled = true;
        upperBodyMovement.enabled = false;

        upperBodyCam.SetActive(false);
        lowerBodyCam.SetActive(true);
        humanBodyCam.SetActive(false);
    }

    public void AttachBody()
    {
        //Debug.Log("AttachBody");
        //Check if mUB is within mLB, keybind, call AttachBody.

        profileImage.sprite = profileSprite[0];
        spawnPos = manananggalLowerGO.transform.position;
        humanGO.SetActive(true);

        manananggalUpperGO.SetActive(false);
        manananggalLowerGO.SetActive(false);

        humanGO.transform.position = spawnPos;

        
    }

    public void DetachBody()
    {
        //Debug.Log("DetachBody");
        ////Check if mUB is within mLB, keybind, call DetachBody.
        //Debug.Log("Body Detached");

        spawnPos = humanGO.transform.position;
        humanGO.SetActive(false);
        manananggalUpperGO.SetActive(true);
        manananggalLowerGO.SetActive(true);

        manananggalUpperGO.transform.position = spawnPos + new Vector3(0f, 1f, 0f);
        manananggalLowerGO.transform.position = spawnPos;
        
        UpperBodyMode();
        //isNight = true;
    }
}
/*
Terms
h       :   Human
mUB     :   Manananggal Upper Body
mLB     :   Manananggal Lower Body
 */
