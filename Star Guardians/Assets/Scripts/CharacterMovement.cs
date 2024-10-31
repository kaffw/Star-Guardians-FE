using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    //public Transform groundCheck;
    //public LayerMask groundLayer;

    private Rigidbody2D rb;
    //private bool isGrounded;
    //private float groundCheckRadius = 0.2f;

    public static bool isManananggal = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isManananggal)
        {
            rb.gravityScale = 0f;
            ManananggalMove();
        }
        else
        {
            rb.gravityScale = 1f;
            HumanMove();
            Jump();
        }
    }

    private void HumanMove()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Jump()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump")) //isGrounded && 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void ManananggalMove()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(moveInputX, moveInputY).normalized; // Normalize to prevent faster diagonal movement
        rb.velocity = moveInput * moveSpeed;
    }
}
