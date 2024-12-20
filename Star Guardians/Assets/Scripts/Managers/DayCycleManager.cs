using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class DayCycleManager : MonoBehaviour
{
    public float timer;

    private Volume volume;
    private ColorAdjustments colorAdjustments;

    private CharacterManager charManager;
    private DayAndNightTaskManager dayAndNightTaskManager;

    //Day/Night transitions
    public bool callLimitMorning = false, callLimitNight = false; //limit call for attach/detach once per morning/night sesssion
    public bool clmExternal = false; //When upper body connects to lower body before morning transition

    public bool endOfDay = true; //day/night transition - manages on and off of lights, day/night increment, etc...

    public GameObject[] lightCollection; //All lights, excluding global light

    //day/night counter text
    public GameObject dayCounterText, nightCounterText;
    public GameObject newspaper, newspaperImage;
    public Sprite[] newspaperImageCollection;

    private void Awake()
    {
        charManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
        dayAndNightTaskManager = GameObject.Find("Day And Night Task Manager").GetComponent<DayAndNightTaskManager>();
        
        volume = GameObject.Find("Global Volume").GetComponent<Volume>();
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);

        lightCollection = GameObject.FindGameObjectsWithTag("Light");
        
        StartCoroutine(DisableLights());
        //StartCoroutine(DayCounter());
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
            if(endOfDay)
            {
                StartCoroutine(NightTransition());
                //StartCoroutine(DayCounter());
                StartCoroutine(NewspaperPopUp());
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
            if(!endOfDay)
            {
                StartCoroutine(DayTransition());
                //StartCoroutine(NightCounter());
                
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

        /*Not included in deployment: skip day/night */
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.M))
        {
            timer = 358f;
        }
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.N))
        {
            timer = 178f;
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

    private IEnumerator DayTransition()
    {
        foreach (GameObject light in lightCollection)
        {
            light.SetActive(true);
        }

        dayAndNightTaskManager.IncrementNight();

        endOfDay = true;
        yield return null;
    }

    private IEnumerator NightTransition()
    {
        StartCoroutine(DisableLights());

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

    private IEnumerator DayCounter()
    {
        //dayCounterText;// = dayAndNightTaskManager.dayCount;
        TextMeshProUGUI dct = dayCounterText.GetComponent<TextMeshProUGUI>();
        dct.text = "Day # " + dayAndNightTaskManager.dayCount.ToString();

        dayCounterText.SetActive(true);
        yield return new WaitForSeconds(1f);
        dayCounterText.SetActive(false);

        yield return null;
    }

    private IEnumerator NightCounter()
    {
        //nightCounterText = dayAndNightTaskManager.nightCount;
        TextMeshProUGUI nct = nightCounterText.GetComponent<TextMeshProUGUI>();
        nct.text = "Night # " + dayAndNightTaskManager.nightCount.ToString();

        nightCounterText.SetActive(true);
        yield return new WaitForSeconds(1f);
        nightCounterText.SetActive(false);

        yield return null;
    }

    private IEnumerator NewspaperPopUp()
    {
        newspaper.SetActive(true);
        //Image img = newspaperImage.GetComponent<Image>(); 
        //img.sprite = newspaperImageCollection[Random.Range(0, newspaperImageCollection.Length)];
        
        yield return new WaitForSeconds(3f);
        newspaper.SetActive(false);

        yield return null;
    }
}
