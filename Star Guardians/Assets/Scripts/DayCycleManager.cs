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
    private void Awake()
    {
        charManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
        
        volume = GameObject.Find("Global Volume").GetComponent<Volume>();
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
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

            StartCoroutine(Attach());
        }
        else if (timer >= 3 * 60 && timer <= 6 * 60)
        {
            //night
            colorAdjustments.postExposure.value = -6f;

            charManager.isNight = true;

            StartCoroutine(Detach());

            if (timer >= 5 * 60)
            {
                //player should locate their lower body
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
}
