using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;

    public static bool isManananggal = false;
    
    public Vector2 boxSize;
    public float castDistance;
    bool grounded;
    public LayerMask groundLayer;

    public static bool inAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inAction = false;
    }

    void Update()
    {
        if(!inAction)
        {
            HumanMove();
            Jump();
        }
        else {
            rb.velocity = Vector2.zero;
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
        grounded = isGrounded();

        if (Input.GetButtonDown("Jump") && grounded) //isGrounded && 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
