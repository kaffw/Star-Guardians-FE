using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScanTaskBehaviour : MonoBehaviour
{
    GameObject itemCollection;
    bool callLimit = true;

    private GameObject taskSpawnerGO;
    private TaskSpawner clearedHandler;

    void Awake()
    {
        taskSpawnerGO = GameObject.Find("Scanner Task");
        clearedHandler = taskSpawnerGO.GetComponent<TaskSpawner>();
        itemCollection = GameObject.Find("Item Collection");
    }

    void Update()
    {
        if (itemCollection.transform.childCount == 0 && callLimit)
        {
            Debug.Log("Scanner Task Cleaered");
            callLimit = false;

            //Task List Update
            clearedHandler.isCleared = true;
            TaskListPopManager.scannerTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);
            
            Destroy(gameObject, 1f);
        }
    }
}
