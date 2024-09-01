using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLights : MonoBehaviour
{
    public float rotationSpeed = 1f;

    private Quaternion targetRotation;
    private Quaternion fromRotation;

    private float timeCount = 0.0f;

    void Start()
    {
        // Capture the initial rotation
        fromRotation = transform.rotation;

        // Initialize the first target rotation
        SetRandomTargetRotation();
    }

    void Update()
    {
        // Smoothly interpolate towards the target rotation
        transform.rotation = Quaternion.Lerp(fromRotation, targetRotation, timeCount);

        // Increment timeCount based on rotation speed and deltaTime
        timeCount += Time.deltaTime * rotationSpeed;

        // When the interpolation is complete (timeCount >= 1), set a new random target
        if (timeCount >= 1.0f)
        {
            fromRotation = transform.rotation;
            SetRandomTargetRotation();
            timeCount = 0.0f; // Reset timeCount for the next interpolation
        }
    }

    void SetRandomTargetRotation()
    {
        // Set a new random rotation target within the specified range
        targetRotation = Quaternion.Euler(
            Random.Range(-35f, 100f),
            Random.Range(-150f, -30f),
            fromRotation.eulerAngles.z // Keep Z axis constant
        );

    }
}
