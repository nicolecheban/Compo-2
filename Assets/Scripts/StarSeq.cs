using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSeq : MonoBehaviour
{
    public LibPdInstance patch;
    float ramp;
    float t;
    int[] mode;
    int count = 0;
    

    [SerializeField]
    List<bool> kick;
    [SerializeField]
    List<bool> snare;
    [SerializeField]
    List<bool> sticks;
    public List<AudioClip> sounds;
    string[] drum_type = new string[] { "Kick", "Snare", "Sticks" };
    List<float> envelopes;
    List<bool>[] gates = new List<bool>[3];
    Vector4 adsr_params;
    [SerializeField] float tempo = 1;

    public Transform obj;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public float duration = 1.0f;

    void Start()
    {
        envelopes = new List<float>();
        for(int i = 0; i < sounds.Count; i++)
        {
            //send sound files names to patch
            //add .wav
            //drum type is both the name of receive obj 
            //and of Drums folder subdirectory for sound
            string name = sounds[i].name + ".wav";
            patch.SendSymbol(drum_type[i], name);
            //build list of envelopes
            envelopes.Add(0);
        }
        gates[0] = kick;
        gates[1] = snare;
        gates[2] = sticks;
        adsr_params = new Vector4(100, 50, 0.4f, 200);


        startPosition = new Vector3(obj.position.x, obj.position.y, obj.position.z); 
        endPosition = new Vector3(obj.position.x + 17f, obj.position.y - 10f, obj.position.z - 4f); 
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        bool trig = ramp > (ramp + Time.deltaTime*tempo) % 1;
        ramp = (ramp + Time.deltaTime*tempo) % 1;

        if (trig)
        {
            if (kick[count])
            {
                patch.SendBang("kick_bang");
                StartCoroutine(AnimateObject());
            } 
            if (snare[count])
            {
                patch.SendBang("snare_bang");
            }
            if (sticks[count])
            {
                patch.SendBang("sticks_bang");
            }
            count = (count + 1) % kick.Count;
        }

        for (int i = 0; i < sounds.Count; i++)
        {
           
            envelopes[i] = ControlFunctions.ADSR(ramp, gates[i][count], adsr_params);
    
        }
    }
    IEnumerator AnimateObject()
{
     // Duration of the animation in seconds
    float elapsedTime = 0;

    while (elapsedTime < duration)
    {
        // Move the obj from startPosition to endPosition
        obj.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / duration));
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    // obj.position = endPosition; // Ensure the object gets to the end position
}
}
