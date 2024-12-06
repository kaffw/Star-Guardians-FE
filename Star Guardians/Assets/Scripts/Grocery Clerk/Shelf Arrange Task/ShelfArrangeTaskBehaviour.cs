using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShelfArrangeTaskBehaviour : MonoBehaviour
{
    public GameObject topShelf, midShelf, botShelf;

    public GameObject[] topShelfItems = new GameObject[4],
                        midShelfItems = new GameObject[4],
                        botShelfItems = new GameObject[4];

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
    }

    private void Update()
    {
        if (topShelf.transform.childCount == 4 &&
            midShelf.transform.childCount == 4 &&
            botShelf.transform.childCount == 4)
        {
            Debug.Log("Arrange Shelf Task Completed");

            //Task List Update
            clearedHandler.isCleared = true;
            TaskListPopManager.shelfTaskText.color = Color.green;
            taskSpawnerGO.SetActive(false);

            Destroy(gameObject, 1f);
        }
    }

    void Unarranged()
    {
        int topItem = Random.Range(0, 4);
        int midItem = Random.Range(0, 4);
        int botItem = Random.Range(0, 4);

        for (int i = 0; i < 4; i++)
        {
            if (i != topItem)
            {
                topShelfItems[i].transform.SetParent(unarrangedHolder.transform);
                topShelfItems[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 3), Random.Range(-3, 4), 0);
            }
            
            if (i != midItem)
            {
                midShelfItems[i].transform.SetParent(unarrangedHolder.transform);
                midShelfItems[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 3), Random.Range(-3, 4), 0);
            }

            if (i != botItem)
            {
                botShelfItems[i].transform.SetParent(unarrangedHolder.transform);
                botShelfItems[i].transform.position = unarrangedHolder.transform.position + new Vector3(Random.Range(-1, 3), Random.Range(-3, 4), 0);
            }
        }
    }
}
//topShelf = transform.Find("Top Shelf").gameObject;
//midShelf = transform.Find("Mid Shelf").gameObject;
//botShelf = transform.Find("Bottom Shelf").gameObject;

//unarrangedHolder = transform.Find("Unarranged")?.gameObject;