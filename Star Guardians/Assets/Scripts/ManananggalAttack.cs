using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManananggalAttack : MonoBehaviour
{
    public bool targetInRange = false;
    //AerialMovement am;

    public GameObject target;

    void Awake()
    {
        //am = GameObject.Find("Upper Body").GetComponent<AerialMovement>();
    }

    void Update()
    {
        if (targetInRange)
        {
            if (Input.GetMouseButtonDown(0) && target != null)
            {
                //am.Attack();
                Attack();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("NPCHunter"))
        {
            //Debug.Log(other.name + "is within manananggal attack range");
            targetInRange = true;
            target = other.gameObject;
        }
    }

    void Attack()
    {
        Debug.Log("Manananggal Attacks" + target.name);
        Destroy(target);
    }
}
