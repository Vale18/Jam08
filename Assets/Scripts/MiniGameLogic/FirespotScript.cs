using UnityEngine;

public class FirespotScript : MiniGameScript
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
