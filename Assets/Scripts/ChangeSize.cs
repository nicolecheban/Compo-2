using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public float scaleSpeed = 0.5f; // Speed of scaling
    public Vector3 maxScale = new Vector3(2, 2, 2); // Maximum scale
    public Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f); // Minimum scale
    public Vector3 scaleIncrement = new Vector3(0.1f, 0.1f, 0.1f); // Scale increment/decrement value

    // Start is called before the first frame update
    void Start()
    {
        targetScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }
    private Vector3 targetScale;
    public void Grow()
    {
        targetScale = Vector3.Min(transform.localScale + scaleIncrement, maxScale);
    }

    public void Shrink()
    {
        targetScale = Vector3.Max(transform.localScale - scaleIncrement, minScale);
    }
}
