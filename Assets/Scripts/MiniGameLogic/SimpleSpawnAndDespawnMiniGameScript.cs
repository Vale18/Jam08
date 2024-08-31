using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnAndDespawn : MiniGameScript
{
    public override void OnStart()
    {
        base.OnStart();
        gameObject.SetActive(true);
    }
    public override void Reset()
    {
        base.Reset();
        gameObject.SetActive(false);
    }
}
