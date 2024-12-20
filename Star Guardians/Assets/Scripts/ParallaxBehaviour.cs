using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    public float scrollSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x + scrollSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x - scrollSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
