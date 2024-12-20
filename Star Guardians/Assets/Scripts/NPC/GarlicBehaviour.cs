using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    CharacterManager chManager;
    AerialMovement am;
    LowerBodyMovementBehaviour lbm;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        chManager = GameObject.FindObjectOfType<CharacterManager>();
        am = GameObject.FindObjectOfType<AerialMovement>().GetComponent<AerialMovement>();
        lbm = GameObject.FindObjectOfType<LowerBodyMovementBehaviour>().GetComponent<LowerBodyMovementBehaviour>();
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
            am.CallHitIndicator();
            Destroy(gameObject);
        }

        if(other.CompareTag("LowerBody"))
        {
            chManager.ReceiveDamage();
            lbm.CallHitIndicator();
            Destroy(gameObject);
        }
    }
}
