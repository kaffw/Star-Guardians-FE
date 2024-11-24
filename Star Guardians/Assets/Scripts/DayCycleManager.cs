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

    public bool callLimitMorning = false, callLimitNight = false;
    public bool clmExternal = false;
    public bool isLightsOn = false;

    public GameObject[] lightCollection;
    private void Awake()
    {
        charManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
        
        volume = GameObject.Find("Global Volume").GetComponent<Volume>();
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);

        lightCollection = GameObject.FindGameObjectsWithTag("Light");
        StartCoroutine(DisableLights());
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

            if (clmExternal) { clmExternal = false; callLimitMorning = false; }
            else StartCoroutine(Attach());

            if (isLightsOn)
            {
                isLightsOn = false;
                StartCoroutine(DisableLights());
            }
        }
        else if (timer >= 3 * 60 && timer <= 6 * 60)
        {
            //night
            colorAdjustments.postExposure.value = -6f;

            charManager.isNight = true;

            StartCoroutine(Detach());

            if (!isLightsOn)
            {
                isLightsOn= true;
                StartCoroutine(EnableLights());
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

    private IEnumerator EnableLights()
    {
        foreach (GameObject light in lightCollection)
        {
            light.SetActive(true);
        }
        isLightsOn = true;
        yield return null;
    }

    private IEnumerator DisableLights()
    {
        foreach (GameObject light in lightCollection)
        {
            light.SetActive(false);
        }
        isLightsOn = false;
        yield return null;
    }
}
