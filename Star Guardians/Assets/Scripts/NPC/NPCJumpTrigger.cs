using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPCJump"))
        {
            NPCMovementBehaviour npcMB = other.transform.parent.GetComponent<NPCMovementBehaviour>();

            StartCoroutine(npcMB.Jump());
        }
    }
}
