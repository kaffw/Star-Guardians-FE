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

    private float levVal;
    private float levTimer;

    void Start()
    {
        isCleared = false;
        levVal = transform.position.y;
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Task instantiated");

                Vector3 spawnPosition = new Vector3(camPos.transform.position.x, camPos.transform.position.y, 0);
                Instantiate(task, spawnPosition, transform.rotation);
            }
        }

        Levitate();
    }

    void Levitate()
    {
        levTimer += Time.deltaTime;
        
        if(levTimer >= 0f && levTimer <= 1f)
            levVal += Time.deltaTime;
        else if(levTimer >= 1f && levTimer <= 2f)
            levVal -= Time.deltaTime;
        else
            levTimer = 0f;

        transform.position = new Vector3(transform.position.x, levVal, transform.position.z);
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
