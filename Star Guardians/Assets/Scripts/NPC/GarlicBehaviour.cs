using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    CharacterManager chManager;
    AerialMovement am;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        chManager = GameObject.FindObjectOfType<CharacterManager>();
        am = GameObject.FindObjectOfType<AerialMovement>().GetComponent<AerialMovement>();
    }

    void Start()
    {
        rb.AddForce(transform.right * 15f, ForceMode2D.Impulse);

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("UpperBody"))
        {
            chManager.ReceiveDamage();
            StartCoroutine(am.HitIndicator());
        }
    }
}
