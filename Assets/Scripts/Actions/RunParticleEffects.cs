using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunParticleEffects : Action
{
    private ParticleSystem particles;
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public override void Execute()
    {
        particles.Play();
    }
}
