using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class TimeOfDayCycleManager : MonoBehaviour
{
    public float dayCycleTimer = 0f;

    public static bool isMorning = true;

    private Volume volume;
    private ColorAdjustments colorAdjustments;

    //enum TimeOfDayEnum { Dawn, Morning, Noon, Dusk, Evening};
    //private string timeOfDay;
    public GameObject Lights; //array soon
    private void Start()
    {
        volume = GameObject.Find("Global Volume").GetComponent<Volume>();

        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            colorAdjustments.postExposure.value = 0f;
            //timeOfDay = TimeOfDayEnum.Morning.ToString();
        }
        else
        {
            Debug.LogError("Color Adjustments override not found in the Volume profile.");
        }
    }
    void Update()
    {
        // I. In game time conversion
        if (dayCycleTimer <= 4 * 15 || (dayCycleTimer > 20 * 15 && dayCycleTimer <= 24 * 15)) //Eve
        {
            //StartCoroutine(PostExposureTransition(colorAdjustments.postExposure.value, -6));
            colorAdjustments.postExposure.value = -6f;

            //Lights.SetActive(true);
            ManananggalMode();
        }
        else if (dayCycleTimer <= 8 * 15) //Dawn
        {
            //StartCoroutine(PostExposureTransition(colorAdjustments.postExposure.value, -2));
            colorAdjustments.postExposure.value = -1f;

            //Lights.SetActive(true);
            ManananggalMode();
        }
        else if (dayCycleTimer <= 12 * 15) //Morning
        {
            //StartCoroutine(PostExposureTransition(colorAdjustments.postExposure.value, -1));
            colorAdjustments.postExposure.value = -.5f;

            //Lights.SetActive(false);
            HumanMode();
        }
        else if (dayCycleTimer <= 16 * 15) //Noon
        {
            //StartCoroutine(PostExposureTransition(colorAdjustments.postExposure.value, 0));
            colorAdjustments.postExposure.value = 0f;

            //Lights.SetActive(false);
            HumanMode();
        }
        else if (dayCycleTimer <= 20 * 15) //Dusk
        {
            //StartCoroutine(PostExposureTransition(colorAdjustments.postExposure.value, -3));
            colorAdjustments.postExposure.value = -3f;

            //Lights.SetActive(true);
            ManananggalMode();
        }


        if (dayCycleTimer >= 3 * 60) //3 minutes day/night
        {
            //night
            //Debug.Log("Currently Night");
            isMorning = false;

            if (dayCycleTimer >= 6 * 60)
            {
                //EndOfDay
                //Debug.Log("End of Day");
                isMorning = true;
                dayCycleTimer = 0;
            }
        }
        else
        {
            //morning
            //Debug.Log("Currently Day");
            isMorning = true;
            //colorAdjustments.postExposure.value = 0f;
        }

        dayCycleTimer += Time.deltaTime;
    }

    public void ManananggalMode()
    {
        Lights.SetActive(true);
        CharacterMovement.isManananggal = true;
    }
    public void HumanMode()
    {
        Lights.SetActive(false);
        CharacterMovement.isManananggal = false;
    }
    private IEnumerator PostExposureTransition(float curr, float target)
    {
        //smoothen transition
        yield return new WaitForSeconds(1f); //duration
    }
}
/*
 simulate day/night
 Lights


----------------------------------------------------------

I. In game time conversion

0 - 60 = 12:0 - 4am	    :	4*15	:	Eve
60 - 120 = 4am - 8am	:	8*15	:	Dawn
120 - 180 = 8am - 12nn	:	12*15	:	Morning
180 - 240 = 12nn - 4pm	:	16*15	:	Noon
240 - 300 = 4pm - 8pm	:	20*15	:	Dusk
300 - 360 = 8pm - 12:0	:	24*15	:	Eve

1h = 15 in game seconds

0.0166666666666667 * 180 = 3 mins
0.0083333333333333 * 360 = 3 mins - 1 12h clock rotation

----------------------------------------------------------
*/