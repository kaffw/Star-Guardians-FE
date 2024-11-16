using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEstablishmentBehaviour : MonoBehaviour
{
    public GameObject indicator;

    public GameObject targetLocation;
    private void Start()
    {
        //get indicator game object by child
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //indicator.SetActive(true);

        if (Input.GetKeyDown(KeyCode.F) && other.CompareTag("Player"))
        {
            Debug.Log("Establishment entered");
            other.transform.position = targetLocation.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //indicator.SetActive(false);
    }
}
