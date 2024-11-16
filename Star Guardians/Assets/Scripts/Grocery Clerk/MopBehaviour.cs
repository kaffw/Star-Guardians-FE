using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopBehaviour : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       
        mousePosition.z = transform.position.z;

        transform.position = mousePosition;
    }
}
