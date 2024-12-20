using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManananggalAttack : MonoBehaviour
{
    public bool targetInRange = false;
    AerialMovement am;

    public GameObject target;
    public GameObject biteVFX;

    TaskListPopManager tlpManager;

    void Awake()
    {
        am = GameObject.Find("Upper Body").GetComponent<AerialMovement>();
        tlpManager = GameObject.FindObjectOfType<TaskListPopManager>();
    }

    void Update()
    {
        if(!AbilityCooldown.abilityInAction)
        {
            if (targetInRange)
            {
                if (Input.GetMouseButtonDown(0) && target != null)
                {
                    AbilityCooldown.devourCooldown = 1f;
                    AbilityCooldown.abilityInAction = true;
                    Attack();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("NPCHunter"))
        {
            targetInRange = true;
            target = other.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("NPCHunter"))
        {
            targetInRange = true;
            target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("NPCHunter"))
        {
            targetInRange = false;
            target = null;;
        }
    }

    void Attack()
    {
        Debug.Log("Manananggal Attacks" + target.name);
        tlpManager.devCount++;
        if(CharacterManager.hp < 3) CharacterManager.hp++;
        
        Instantiate(biteVFX, target.transform.position, transform.rotation);
        StartCoroutine(am.AttackDash(target));

        target.SetActive(false);
        target = null;
    }
}
