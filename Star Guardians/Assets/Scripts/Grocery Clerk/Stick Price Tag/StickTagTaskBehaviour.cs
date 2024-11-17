using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTagTaskBehaviour : MonoBehaviour
{
    public GameObject[] unpricedItems;
    void Update()
    {
        foreach (var item in unpricedItems)
        {
            if (item.transform.childCount != 1)
            {
                break;
            }
            Debug.Log("All items have price tag");
            Destroy(gameObject, 1f);
        }
    }
}
