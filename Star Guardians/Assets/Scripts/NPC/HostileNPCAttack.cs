using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileNPCAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject target;
    
    private float attackRate = 2f;
    private float attackTimer = 0f;
    private bool targetInRange = false;

    Vector3 Look;
    float angle;

    void Update()
    {
        attackTimer += Time.deltaTime;

        if(target != null)Look = transform.InverseTransformPoint(target.transform.position);
        angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg;

        if(targetInRange && attackTimer >= attackRate && target != null)
        {
            attackTimer = 0f;
            Attack();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("UpperBody") || other.CompareTag("LowerBody"))
        {
            targetInRange = true;
            target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("UpperBody") || other.CompareTag("LowerBody"))
        {
            targetInRange = false;
            target = null;
        }
    }

    void Attack()
    {
        Vector3 rotation = new Vector3(0,0,angle);
        Quaternion rotationQuaternion = Quaternion.Euler(rotation);

        Instantiate(bulletPrefab, gameObject.transform.position, rotationQuaternion);
        Debug.Log("Hostile NPC attacks");
    }
}
