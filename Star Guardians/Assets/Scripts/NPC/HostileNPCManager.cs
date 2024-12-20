using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileNPCManager : MonoBehaviour
{
    public GameObject[] hostilenpcs;

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
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            hostilenpcs[i].SetActive(true);
        }
    }
}
