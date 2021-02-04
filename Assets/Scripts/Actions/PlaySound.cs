using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Action
{
    private AudioSource audio;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void Execute()
    {
        audio.Play();
    }
}
