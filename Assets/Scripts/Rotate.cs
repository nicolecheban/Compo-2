using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationAngle = 90.0f;
    public float rotationDuration = 1.0f;
    private bool isRotating = false;
    public void StartRotate()
    {
        if (!isRotating)
        {
            StartCoroutine(Rotation(rotationAngle, rotationDuration));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Rotation(float amount, float duration)
    {
        isRotating = true;

        // Record the start rotation and calculate the target rotation
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(0, 0, amount);

        // Rotate over time
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration; // Normalized time from 0 to 1
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, normalizedTime);
            yield return null; // Wait until the next frame
        }

        // Ensure the rotation exactly matches the target rotation after the loop
        transform.rotation = endRotation;

        isRotating = false;
    }
}
