using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveExpiredTaskBehaviour : MonoBehaviour
{
    public GameObject expiringItems;
    public int expiredItemsRemoved;
    private bool oneInstance = true;
    private void Start()
    {
        StartCoroutine(SetExpiredItemsRemoved());
    }
    private void Update()
    {
        if (expiredItemsRemoved == 0 && !oneInstance)
        {
            oneInstance = true;
            Debug.Log("Remove Expired Products Task Completed");
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
