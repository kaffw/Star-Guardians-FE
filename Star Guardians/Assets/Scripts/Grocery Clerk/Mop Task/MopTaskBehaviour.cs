using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopTaskBehaviour : MonoBehaviour
{
    public GameObject puddle;
    public GameObject mop;

    private GameObject puddleCollection;
    private bool oneInstance = false;
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
            Destroy(gameObject, 1f);
        }
    }
}

/*
    x = -5, 5
    y = -3, 3
 */
