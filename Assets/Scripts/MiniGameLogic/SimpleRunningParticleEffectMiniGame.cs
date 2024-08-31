using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRunningParticleEffect : MiniGameScript
{
    ParticleSystem sparks;
    public void Start()
    {
        sparks = GetComponentInChildren<ParticleSystem>();
    }
    public override void OnStart()
    {
        base.OnStart();
        sparks.Play();
    }
    public override void Reset()
    {
        base.Reset();
        sparks.Stop();
    }
}
