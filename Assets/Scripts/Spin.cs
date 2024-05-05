using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 10f;
    public char axis;
    public string direction = "clockwise";
    private int d;

    // Start is called before the first frame update
    
    void Start()
    {
        if (direction == "Clockwise" || direction == "clockwise") {
            d = 1;
        }
        if (direction == "Counterclockwise" || direction == "counterclockwise") {
            d = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == 'x') {
            transform.Rotate(d*speed * Time.deltaTime, 0f, 0f);
        }
        if (axis == 'y') {
            transform.Rotate(0f, d*speed * Time.deltaTime, 0f);
        }
        if (axis == 'z') {
            transform.Rotate(0f, 0f, d*speed * Time.deltaTime);
        }
    }
}
