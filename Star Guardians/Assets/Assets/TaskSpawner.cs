using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    public GameObject task;
    public GameObject camPos;

    [SerializeField]
    bool inRange = false;

    public bool isCleared;

    void Start()
    {
        isCleared = false;
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Task instantiated");

                Vector3 spawnPosition = new Vector3(camPos.transform.position.x, camPos.transform.position.y, 0);
                Instantiate(task, spawnPosition, transform.rotation);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            inRange = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            inRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            inRange = false;
    }
}
