using System.Collections;
using UnityEngine;

public class NPCMovementBehaviour : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] patrolPoints;
    private int destinationIndex;
    private bool targetReached = true;

    private Rigidbody2D rb;
    private bool inJump = false;

    private Coroutine moveCoroutine;

    private int targetFloor;

    private bool isPanic;
    private bool isHostile;

    private GameObject ub;
    
    public enum NPCTypeEnum { Nonhostile, Hostile }
    public NPCTypeEnum npcType;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        isPanic = false;
        isHostile = false;
    }

    void Update()
    {
        if (targetReached && !inJump && !isPanic)
        {
            SetTargetPoint();
        }
        if(npcType == NPCTypeEnum.Hostile)
        {
            if(isHostile)
            {
                if(!targetReached)
                {
                    StopAllCoroutines();
                    targetReached = true;
                    rb.velocity = new Vector3(0, 0, 0);
                }

                Hostile();
            }
        }
        else
        {
            if(isPanic)
            {
                if(!targetReached)
                {
                    StopAllCoroutines();
                    targetReached = true;
                    rb.velocity = new Vector3(0, 0, 0);
                }

                Panic();
            }
        }
    }

    IEnumerator Move()
    {
        while (Vector3.Distance(transform.position, patrolPoints[destinationIndex].position) > 0.1f && !inJump)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[destinationIndex].position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        if (!inJump)
        {
            yield return new WaitForSeconds(Random.Range(2, 7));
            transform.position = patrolPoints[destinationIndex].position;
            targetReached = true;
        }
    }

    void SetTargetPoint()
    {
        destinationIndex = Random.Range(0, patrolPoints.Length);
        targetReached = false;
        moveCoroutine = StartCoroutine(Move());
    }

    public IEnumerator Jump()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        inJump = true;
        rb.velocity = new Vector3(0, 10, 0);
        yield return new WaitForSeconds(1f);

        inJump = false;
        targetReached = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UpperBody"))
        {
            ub = other.gameObject;

            if(npcType == NPCTypeEnum.Hostile)
            {
                moveSpeed = 5f;
                isHostile = true;
            }
            else
            {
                moveSpeed = 4f;
                isPanic = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("UpperBody"))
        {
            moveSpeed = 2f;
            isPanic = false;
            isHostile = false;
        }
    }

    void Panic()
    {
        float direction = (transform.position.x > ub.transform.position.x) ? 1f : -1f;

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    void Hostile()
    {
        float direction = (transform.position.x < ub.transform.position.x) ? 1f : -1f;

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
}
