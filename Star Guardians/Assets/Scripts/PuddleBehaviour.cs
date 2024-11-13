using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PuddleBehaviour : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color color;
    private int counter;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        counter = 0;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mop"))
        {
            color = sr.color;
            color.a /= 1.3f;

            sr.color = color;
            counter++;

            if (counter == 3)
            {
                Debug.Log("Area cleaned");
                Destroy(gameObject);
            }
        }
    }
}
