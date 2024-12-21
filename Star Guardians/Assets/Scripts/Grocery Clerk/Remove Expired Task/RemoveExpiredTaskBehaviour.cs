using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoveExpiredTaskBehaviour : MonoBehaviour
{
    public GameObject expiringItems;
    public int expiredItemsRemoved;
    private bool oneInstance = true;

    private GameObject taskSpawnerGO;
    private TaskSpawner clearedHandler;

    void Awake()
    {
        taskSpawnerGO = GameObject.Find("Expire Task");
        clearedHandler = taskSpawnerGO.GetComponent<TaskSpawner>();
    }

    private void Start()
    {
        StartCoroutine(SetExpiredItemsRemoved());
        CharacterMovement.inAction = true;
    }
    private void Update()
    {
        if (expiredItemsRemoved == 0 && !oneInstance)
        {
            oneInstance = true;
            Debug.Log("Remove Expired Products Task Completed");

            //Task List Update
            clearedHandler.isCleared = true;
            TaskListPopManager.expireTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);

            CharacterMovement.inAction = false;
            Destroy(gameObject, 1f);
        }
        else if(!oneInstance) expiredItemsRemoved = transform.Find("Expired Items").childCount;
    }

    IEnumerator SetExpiredItemsRemoved()
    {
        yield return new WaitForSeconds(0.1f);
        expiredItemsRemoved = transform.Find("Expired Items").childCount;
        oneInstance = false;
    }
}
