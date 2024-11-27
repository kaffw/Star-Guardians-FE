using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTaskBehaviour : MonoBehaviour
{
    GameObject itemCollection;
    bool callLimit = true;

    void Awake()
    {
        itemCollection = GameObject.Find("Item Collection");
    }

    void Update()
    {
        if (itemCollection.transform.childCount == 0 && callLimit)
        {
            Debug.Log("Scanner Task Cleaered");
            callLimit = false;
            Destroy(gameObject, 1f);
        }
    }
}
