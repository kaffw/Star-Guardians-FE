using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ManananggalMove();
    }

    private void ManananggalMove()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(moveInputX, moveInputY).normalized; // Normalize to prevent faster diagonal movement
        rb.velocity = moveInput * moveSpeed;
    }

    public void Attack()
    {
        //tahm kench Q
        Debug.Log("Manananggal Attacks");
    }

    public void Descent()
    {
        //slowly lowers the y pos
        transform.position = new Vector2(transform.position.x, transform.position.y - (0.5f * Time.deltaTime));
    }

    public IEnumerator AttackDash(GameObject target)
    {
        float dashSpeed = 10f;
        float dashDuration = 1f;
    
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = target.transform.position;
    
        float journeyLength = Vector3.Distance(startPosition, targetPosition);

        float distanceCovered = 0f;
    
        rb.isKinematic = true;

        while (distanceCovered < journeyLength)
        {
            float step = dashSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        
            distanceCovered += step;
        
            yield return null; 
        }

        rb.isKinematic = false;

        yield return null;
    }
}

