using System.Collections;
using UnityEngine;

public class NPCMovementBehaviour : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] patrolPoints;
    private int destinationIndex;
    private bool targetReached = true;

    public Collider2D[] collidersToCheck;
    void Update()
    {
        if (targetReached)
        {
            SetTargetPoint();
        }
    }

    IEnumerator Move()
    {
        while (Vector3.Distance(transform.position, patrolPoints[destinationIndex].position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[destinationIndex].position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(Random.Range(2, 7));

        transform.position = patrolPoints[destinationIndex].position;
        targetReached = true;
    }

    void SetTargetPoint()
    {
        destinationIndex = Random.Range(0, patrolPoints.Length);
        targetReached = false;
        StartCoroutine(Move());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UpperBody"))
        {
            moveSpeed = 5f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("UpperBody"))
        {
            moveSpeed = 2f;
        }
    }
}
