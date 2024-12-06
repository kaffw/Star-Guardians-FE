using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MopTaskBehaviour : MonoBehaviour
{
    public GameObject puddle;
    public GameObject mop;

    private GameObject puddleCollection;
    private bool oneInstance = false;

    private GameObject taskSpawnerGO;
    private TaskSpawner clearedHandler;

    void Awake()
    {
        taskSpawnerGO = GameObject.Find("Mop Task");
        clearedHandler = taskSpawnerGO.GetComponent<TaskSpawner>();
    }

    void Start()
    {
        puddleCollection = gameObject.transform.Find("Puddles").gameObject;

        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            GameObject newPuddle = Instantiate(
                puddle,
                transform.position + new Vector3(Random.Range(-5, 6), Random.Range(-5, 6), 0),
                transform.rotation
            );
            newPuddle.transform.SetParent(puddleCollection.transform);
        }

        GameObject newMop = Instantiate(mop);
        newMop.transform.SetParent(gameObject.transform);
    }

    void Update()
    {
        if (puddleCollection.transform.childCount == 0 && !oneInstance)
        {
            oneInstance = true;

            Debug.Log("Task Cleared!");

            //Task List Update
            clearedHandler.isCleared = true;
            TaskListPopManager.mopTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);

            Destroy(gameObject, 1f);
        }
    }
}
