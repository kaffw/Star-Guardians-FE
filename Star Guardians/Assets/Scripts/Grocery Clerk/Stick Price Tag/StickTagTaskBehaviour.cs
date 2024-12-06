using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StickTagTaskBehaviour : MonoBehaviour
{
    public GameObject[] unpricedItems;

    private GameObject taskSpawnerGO;
    private TaskSpawner clearedHandler;

    void Awake()
    {
        taskSpawnerGO = GameObject.Find("Tag Task");
        clearedHandler = taskSpawnerGO.GetComponent<TaskSpawner>();
    }

    void Update()
    {
        //Task List Update
        foreach (var item in unpricedItems)
        {
            if (item.transform.childCount != 1)
            {
                break;
            }
            Debug.Log("All items have price tag");

            clearedHandler.isCleared = true;
            TaskListPopManager.tagTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);

            Destroy(gameObject, 1f);
        }
    }
}
