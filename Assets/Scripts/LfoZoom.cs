using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LfoZoom : MonoBehaviour
{
    public float amplitude = 1.0f; // Amplitude of the sine wave
    public float frequency = 0.05f; // Frequency of the sine wave
    public float phaseAmt = 0;
    private float phase; // Phase of the sine wave
    public float speed; // Speed of the object, derived from the sine wave
    void Start(){
        phase = phaseAmt * Mathf.PI/2;
    }
    void Update()
    {
        // Increment the phase each frame, wrapping around using 2*PI to complete the cycle
        phase += 2 * Mathf.PI * frequency * Time.deltaTime;
        if (phase >= 2 * Mathf.PI) phase -= 2 * Mathf.PI;

        // Calculate speed based on the derivative of the sine wave (which is cosine)
        speed = amplitude * Mathf.Cos(phase);

        // Move the object based on the current speed
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
}
