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

    //States
    public enum BodyState { Human, Manananggal };
    public BodyState state;

    //GameObjects - Player Bodies
    public GameObject humanGO;
    public GameObject manananggalUpperGO;
    public GameObject manananggalLowerGO;
    Vector3 spawnPos;

    //Manananggal Devour Attack
    public AerialMovement am;
    public GameObject abilityIcon;
    private bool abilityCallOnce;

    //Stats
    public static int hp;
    private float iF; // I-Frame

    void Awake()
    {
        am = GameObject.Find("Upper Body").GetComponent<AerialMovement>();
        abilityCallOnce = false;

        hp = 3;
        iF = 1f;
    }

    void Update()
    {
        if (isNight)
        {
            state = BodyState.Manananggal;

            if(!abilityCallOnce)
            {
                abilityCallOnce = true;
                abilityIcon.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UpperBodyMode();
                abilityIcon.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                LowerBodyMode();
                abilityIcon.SetActive(false);
            }
        }
        else
        {
            state = BodyState.Human;
            abilityCallOnce = false;
            humanBodyCam.SetActive(true);
            abilityIcon.SetActive(false);
        }

        if (state == BodyState.Manananggal)
        {
            am.Descent();
        }

        if(hp == 0)
        {
            Debug.Log("Game Over");
        }

        iF -= Time.deltaTime;
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
        spawnPos = manananggalLowerGO.transform.position + new Vector3(0f ,1f ,0f);
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

        manananggalUpperGO.transform.position = spawnPos;
        manananggalLowerGO.transform.position = spawnPos - new Vector3(0f, 1f, 0f);
        
        UpperBodyMode();
        //isNight = true;
    }

    public void ReceiveDamage()
    {
        if(iF <= 0)
        {
            hp--;
            Debug.Log("hp = " + hp);
        }

        iF = 1f;
    }
}
/*
Terms
h       :   Human
mUB     :   Manananggal Upper Body
mLB     :   Manananggal Lower Body
 */
