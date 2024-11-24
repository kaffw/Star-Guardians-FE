using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBodyTrigger : MonoBehaviour
{
    private bool en = false;
    public DayCycleManager dcm;
    public CharacterManager cm;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)) en = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UpperBody") && en)
        {
            dcm.callLimitMorning = true;
            
            en = false;
            //cm.UpperBodyMode();
            StartCoroutine(dcm.Attach());
            dcm.clmExternal = true;
            cm.humanBodyCam.SetActive(true);
        }
    }
}
