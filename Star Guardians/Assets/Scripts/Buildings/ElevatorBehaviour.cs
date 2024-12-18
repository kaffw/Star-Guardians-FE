using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviour : MonoBehaviour
{
    public GameObject upper, lower;
    public GameObject upIndicator, downIndicator;
    private bool handler;
    
    private GameObject player;

    void Update()
    {
        if(handler)
        {
            if(upper != null)
            {
                upIndicator.SetActive(true);

                if(Input.GetKeyDown(KeyCode.W))
                {
                    player.transform.position = upper.transform.position;
                }
            }
            
            if(lower != null)
            {
                downIndicator.SetActive(true);

                if (Input.GetKeyDown(KeyCode.S))
                {
                    player.transform.position = lower.transform.position;
                }
            }
        }
        else
        {
            upIndicator.SetActive(false);
            downIndicator.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            handler = true;
            player = other.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            handler = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            handler = false;
            player = null;
        }
    }
}
