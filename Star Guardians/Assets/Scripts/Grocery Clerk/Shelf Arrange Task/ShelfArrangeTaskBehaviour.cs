using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShelfArrangeTaskBehaviour : MonoBehaviour
{
    //Shelf[8]
    public GameObject shelf11, shelf12, shelf13, shelf14, shelf21, shelf22, shelf23, shelf24;

    //ShelfContents[8][4]
    public GameObject[] shelf11Items = new GameObject[4],
                        shelf12Items = new GameObject[4],
                        shelf13Items = new GameObject[4],
                        shelf14Items = new GameObject[4],
                        shelf21Items = new GameObject[4],
                        shelf22Items = new GameObject[4],
                        shelf23Items = new GameObject[4],
                        shelf24Items = new GameObject[4];

    public GameObject unarrangedHolder;

    private GameObject taskSpawnerGO;
    private TaskSpawner clearedHandler;

    void Awake()
    {
        taskSpawnerGO = GameObject.Find("Shelf Task");
        clearedHandler = taskSpawnerGO.GetComponent<TaskSpawner>();
    }

    private void Start()
    {
        Unarranged();
        CharacterMovement.inAction = true;
    }

    private void Update()
    {
        if (shelf11.transform.childCount == 4 &&
            shelf12.transform.childCount == 4 &&
            shelf13.transform.childCount == 4 &&
            shelf14.transform.childCount == 4 &&
            shelf21.transform.childCount == 4 &&
            shelf22.transform.childCount == 4 &&
            shelf23.transform.childCount == 4 &&
            shelf24.transform.childCount == 4
        )
        {
            Debug.Log("Arrange Shelf Task Completed");

            //Task List Update
            clearedHandler.isCleared = true;
            TaskListPopManager.shelfTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);
            CharacterMovement.inAction = false;
            Destroy(gameObject, 1f);
        }
    }

    void Unarranged()
    {
        int shelf11Item = Random.Range(0, 4);
        int shelf12Item = Random.Range(0, 4);
        int shelf13Item = Random.Range(0, 4);
        int shelf14Item = Random.Range(0, 4);
        int shelf21Item = Random.Range(0, 4);
        int shelf22Item = Random.Range(0, 4);
        int shelf23Item = Random.Range(0, 4);
        int shelf24Item = Random.Range(0, 4);

        for (int i = 0; i < 4; i++)
        {
            if (i != shelf11Item)
            {
                shelf11Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf11Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }
            
            if (i != shelf12Item)
            {
                shelf12Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf12Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }

            if (i != shelf13Item)
            {
                shelf13Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf13Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }

            if (i != shelf14Item)
            {
                shelf14Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf14Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }

            if (i != shelf21Item)
            {
                shelf21Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf21Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }
            
            if (i != shelf22Item)
            {
                shelf22Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf22Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }

            if (i != shelf23Item)
            {
                shelf23Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf23Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }

            if (i != shelf24Item)
            {
                shelf24Items[i].transform.SetParent(unarrangedHolder.transform);
                shelf24Items[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 7), 0);
            }
        }
    }
}