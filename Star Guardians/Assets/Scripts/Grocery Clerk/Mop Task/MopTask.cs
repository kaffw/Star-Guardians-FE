using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopTask : MonoBehaviour
{
    public GameObject task;
    private bool interact = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interact)
        {
            GameObject camPos = GameObject.Find("Main Camera");
            Vector3 spawnPosition = new Vector3(camPos.transform.position.x, camPos.transform.position.y, 0);
            Instantiate(task, spawnPosition, transform.rotation);
            interact = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) interact = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) interact = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) interact = false;
    }
}
/*
         if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("Player"))
        {
            Debug.Log("Task instantiated");

            GameObject camPos = GameObject.Find("Main Camera");
            Vector3 spawnPosition = new Vector3(camPos.transform.position.x, camPos.transform.position.y, 0);
            Instantiate(task, spawnPosition, transform.rotation);
        }
 */