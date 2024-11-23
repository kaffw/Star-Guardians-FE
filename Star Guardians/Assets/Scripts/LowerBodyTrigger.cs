using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBodyTrigger : MonoBehaviour
{
    private bool en = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)) en = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UpperBody"))
        {
            DayCycleManager dcm = GameObject.Find("DayCycleManager").GetComponent<DayCycleManager>();
            dcm.callLimitMorning = true;
            en = false;
            //StartCoroutine(dcm.Attach());
        }
    }
}
