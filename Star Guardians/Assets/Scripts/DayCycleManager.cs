using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayCycleManager : MonoBehaviour
{
    public float timer;

    private Volume volume;
    private ColorAdjustments colorAdjustments;

    private CharacterManager charManager;
    private DayAndNightTaskManager dayAndNightTaskManager;

    public bool callLimitMorning = false, callLimitNight = false; //limit call for attach/detach once per morning/night sesssion
    public bool clmExternal = false; //When upper body connects to lower body before morning transition
    //public bool isLightsOn = false;
    public bool endOfDay = true; //day/night transition - manages on and off of lights, day/night increment, etc...

    public GameObject[] lightCollection; //All lights, excluding global light
    private void Awake()
    {
        charManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
        dayAndNightTaskManager = GameObject.Find("Day And Night Task Manager").GetComponent<DayAndNightTaskManager>();
        
        volume = GameObject.Find("Global Volume").GetComponent<Volume>();
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);

        lightCollection = GameObject.FindGameObjectsWithTag("Light");
        StartCoroutine(DisableLights());
        //StartCoroutine(NightTransition());
    }
    void Start()
    {
        callLimitMorning = true;
        callLimitNight = true;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= 3 * 60)
        {
            //morning
            colorAdjustments.postExposure.value = 0f;

            charManager.isNight = false;

            //if - Manananggal Upper Body attaches to the lower body before transitioning to morning
            //else - default attach instantly (subject to change)
            //else v2 - game over, die by hunger/ sunrise, restart game to day 1
            if (clmExternal) { clmExternal = false; callLimitMorning = false; }
            else StartCoroutine(Attach());

            //Day Increment
            if(endOfDay)//if (isLightsOn)
            {
                //isLightsOn = false;
                
                //StartCoroutine(DisableLights());
                StartCoroutine(NightTransition());
                endOfDay = false;
            }
        }
        else if (timer >= 3 * 60 && timer <= 6 * 60)
        {
            //night
            colorAdjustments.postExposure.value = -6f;

            charManager.isNight = true;

            StartCoroutine(Detach());

            // Night Increment
            if(!endOfDay)//if (!isLightsOn)
            {
                //isLightsOn= true;
                
                //StartCoroutine(EnableLights());
                StartCoroutine(DayTransition());
                endOfDay = true;
            }

            if (timer >= 5 * 60)
            {
                //player should locate their lower body
                //ignore for now
            }
        }
        else
        {
            timer = 0f;

            callLimitMorning = true;
            callLimitNight = true;
        }
    }

    public IEnumerator Attach()
    {
        if (callLimitMorning)
        {
            callLimitMorning = false;
            charManager.AttachBody();
        }
        yield return null;
    }

    public IEnumerator Detach()
    {
        if (callLimitNight)
        {
            callLimitNight = false;
            charManager.DetachBody();
        }
        yield return null;
    }

    private IEnumerator DayTransition()//EnableLights()
    {
        foreach (GameObject light in lightCollection)
        {
            light.SetActive(true);
        }
        //isLightsOn = true;

        dayAndNightTaskManager.IncrementNight();

        endOfDay = true;
        yield return null;
    }

    private IEnumerator NightTransition()//DisableLights()
    {
        StartCoroutine(DisableLights());

        //isLightsOn = false;

        dayAndNightTaskManager.IncrementDay();

        endOfDay = false;
        yield return null;
    }

    private IEnumerator DisableLights()
    {
        foreach (GameObject light in lightCollection)
        {
            light.SetActive(false);
        }

        yield return null;
    }
}
