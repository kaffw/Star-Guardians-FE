using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHandPivot : MonoBehaviour
{
    public float rotationSpeed = 2f;
    private float hourRotation = 0f;

    void Update()
    {
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        hourRotation += rotationThisFrame;

        if (hourRotation >= 360f)
        {
            hourRotation -= 360f;
        }

        transform.rotation = Quaternion.Euler(0, 0, -hourRotation);
    }
}
