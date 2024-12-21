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
        CharacterMovement.inAction = true;
    }

    void Update()
    {
        //Task List Update
        /*foreach (var item in unpricedItems)
        {
            if (item.transform.childCount != 1)
            {
                break;
            }
            Debug.Log("All items have price tag");

            clearedHandler.isCleared = true;
            TaskListPopManager.tagTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);
            CharacterMovement.inAction = false;
            Destroy(gameObject, 1f);
        }*/

        if(unpricedItems[0].transform.childCount == 1 &&
        unpricedItems[1].transform.childCount == 1 &&
        unpricedItems[2].transform.childCount == 1 &&
        unpricedItems[3].transform.childCount == 1)
        {
            clearedHandler.isCleared = true;
            TaskListPopManager.tagTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);
            CharacterMovement.inAction = false;
            Destroy(gameObject, 1f);
        }
    }
}
