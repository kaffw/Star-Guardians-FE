using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBodyMovementBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Jump force
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    //public Transform groundCheck;
    //public LayerMask groundLayer;
    //private bool isGrounded;

    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        moveInput = Input.GetAxisRaw("Horizontal");

        MovePlayer();

        if (Input.GetButtonDown("Jump")) //isGrounded && 
        {
            Jump();
        }

        //if (Input.GetKeyDown(KeyCode.J)) objectiveCleaered = true;
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public IEnumerator HitIndicator()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sr.color = Color.white;

        yield return null;
    }

    public void CallHitIndicator()
    {
        StartCoroutine(HitIndicator());
    }
}
