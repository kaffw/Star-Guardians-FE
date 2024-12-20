using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using TMPro;
using System;

public class DayAndNightTaskManager : MonoBehaviour
{
    public int dayCount = 1, nightCount = 0;
    bool dayLimit, nightLimit;

    private CharacterManager charManager;
    private NPCManager npcManager;
    private HostileNPCManager hnpcManager;

    public TextMeshProUGUI  dayText, dayTextShadow;
    private string[] days = new string[5];
    private enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    private void Awake()
    {
        charManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
        npcManager = GameObject.FindObjectOfType<NPCManager>();
        hnpcManager = GameObject.FindObjectOfType<HostileNPCManager>();
    }

    private void Start()
    {
        int i = 0;
        foreach (Days day in Enum.GetValues(typeof(Days)))
        {
            days[i] = day.ToString();
            i++;
        }

        AssignDayTask();
        hnpcManager.DisableNPC();
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
        dayText.text = days[dayCount - 1];
        dayTextShadow.text = days[dayCount - 1];
        /*switch (dayCount) not yet used
        {
            case 1: Debug.Log("day 1 task"); break;
            case 2: Debug.Log("day 2 task"); break;
            case 3: Debug.Log("day 3 task"); break;
            case 4: Debug.Log("day 4 task"); break;
            case 5: Debug.Log("day 5 task"); break;
        }*/
    }

    void AssignNightTask()
    {
        //assign night task here
        /*switch (nightCount) not yet used
        {
            case 1: Debug.Log("night 1 task"); break;
            case 2: Debug.Log("night 2 task"); break;
            case 3: Debug.Log("night 3 task"); break;
            case 4: Debug.Log("night 4 task"); break;
            case 5: Debug.Log("night 5 task"); break;
        }*/
    }

    public void IncrementDay()
    {
        dayCount++;
        dayLimit = true;
        
        //Activate NPCs
        npcManager.ResetNPC();
        hnpcManager.DisableNPC();

        Debug.Log("dCount = " + dayCount);
    }

    public void IncrementNight()
    {
        nightCount++;
        nightLimit = true;

        //Activate holstile NPCS
        hnpcManager.ResetHostileNPC();
        
        Debug.Log("nCount = " + nightCount);
    }

}
