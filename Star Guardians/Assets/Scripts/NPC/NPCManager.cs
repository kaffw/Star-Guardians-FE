using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject[] npcs;
    
    void Start()
    {
        npcs = new GameObject[gameObject.transform.childCount];

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            npcs[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    public void ResetNPC()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            npcs[i].SetActive(true);
        }
    }
}
