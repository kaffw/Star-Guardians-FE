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
}
