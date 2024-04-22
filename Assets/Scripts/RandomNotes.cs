using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNotes : MonoBehaviour
{
  public LibPdInstance patch;
  float ramp;
  float t;
  int[] mode;
  int count = 0;
    // Add a toggle button in Unity
  public bool toggle;
  [SerializeField]
  List<bool> steps;

  // Start is called before the first frame update
  void Start()
  {
      mode = new int[]{2,2,3,2,2};
      // Set the toggle to false
      toggle = false;
  }

  // Update is called once per frame
  void Update()
  {
     t += Time.deltaTime;
    
    bool trig = ramp > (ramp + Time.deltaTime) % 1;
    ramp = (ramp + Time.deltaTime) % 1;
    float env = Mathf.Pow(1 - ramp, 7);

  if (trig) {
    if (steps[count]) {
        int randomPitch = UnityEngine.Random.Range(60, 73); // 73 is exclusive
        patch.SendMidiNoteOn(0, randomPitch, 80);
    }
    count = (count + 1) % steps.Count;
  }
      
  }
}
