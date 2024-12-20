using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileNPCManager : MonoBehaviour
{
    public GameObject[] hostilenpcs;

    DayAndNightTaskManager dntManager;

    void Awake()
    {
        dntManager = GameObject.FindObjectOfType<DayAndNightTaskManager>();
    }

    void Start()
    {
        hostilenpcs = new GameObject[gameObject.transform.childCount];
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            hostilenpcs[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    public void DisableNPC()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            hostilenpcs[i].SetActive(false);
        }
    }

    public void ResetHostileNPC()
    {
        int disableCount = dntManager.nightCount;
        disableCount = (10) - (disableCount * 2);
        int disabledItr = 0;

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            if(disabledItr == disableCount)
            {
               hostilenpcs[i].SetActive(true); 
            }
            else
            {
                int rand = Random.Range(0, 2);
                if(rand == 0 && disabledItr < disableCount)
                {
                    hostilenpcs[i].SetActive(true);
                }
                else
                {
                    disabledItr++;
                    hostilenpcs[i].SetActive(false);
                }
            }
        }
    }
}
