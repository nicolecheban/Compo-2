using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAtStart : MonoBehaviour
{
    public LibPdInstance patch;
    

    [SerializeField]
    List<bool> kick;
    public List<AudioClip> sounds;
    string[] drum_type = new string[] { "Kick" };
    List<float> envelopes;
    List<bool>[] gates = new List<bool>[1];
    Vector4 adsr_params;

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
        adsr_params = new Vector4(100, 50, 0.4f, 200);

        patch.SendBang("kick_bang");
    }

    // Update is called once per frame
    void Update()
    {
    }
}