using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class DayAndNightTaskManager : MonoBehaviour
{
    public int dayCount = 1, nightCount = 0;
    bool dayLimit, nightLimit;

    private CharacterManager charManager;
    private void Awake()
    {
        charManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
    }
    private void Start()
    {
        Debug.Log("dCount = " + dayCount);
        Debug.Log("nCount = " + nightCount);

        AssignDayTask();
    }

    private void Update()
    {
        if (!charManager.isNight && dayLimit)
        {
            //morning
            AssignDayTask();
            dayLimit = false;
            
        }
        else if(charManager.isNight && nightLimit)
        {
            //night
            AssignNightTask();
            nightLimit = false;
            
        }
    }
    void AssignDayTask()
    {
        //assign day task here
        switch (dayCount)
        {
            case 1: Debug.Log("day 1 task"); break;
            case 2: Debug.Log("day 2 task"); break;
            case 3: Debug.Log("day 3 task"); break;
            case 4: Debug.Log("day 4 task"); break;
            case 5: Debug.Log("day 5 task"); break;
        }
    }

    void AssignNightTask()
    {
        //assign night task here
        switch (nightCount)
        {
            case 1: Debug.Log("night 1 task"); break;
            case 2: Debug.Log("night 2 task"); break;
            case 3: Debug.Log("night 3 task"); break;
            case 4: Debug.Log("night 4 task"); break;
            case 5: Debug.Log("night 5 task"); break;
        }
    }

    public void IncrementDay()
    {
        dayCount++;
        dayLimit = true;
        Debug.Log("dCount = " + dayCount);
    }

    public void IncrementNight()
    {
        nightCount++;
        nightLimit = true;
        Debug.Log("nCount = " + nightCount);
    }

}
