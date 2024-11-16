using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    public GameObject task;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("Player"))
        {
            Debug.Log("Task instantiated");

            GameObject camPos = GameObject.Find("Main Camera");
            Vector3 spawnPosition = new Vector3(camPos.transform.position.x, camPos.transform.position.y, 0);
            Instantiate(task, spawnPosition, transform.rotation);
        }
    }
}
