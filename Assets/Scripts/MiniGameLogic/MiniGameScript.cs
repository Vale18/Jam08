using UnityEngine;

public class MiniGameScript : MonoBehaviour
{
    public string description = "Bringe Müll weg";
    public int happiness;
    public float spawnTime;
    public int maxDuration;
    public virtual void OnStart()
    {
        spawnTime = Time.time;
    }
    public virtual void Reset()
    {

    }
    public virtual void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    [ContextMenu("OnComplete")]
    public virtual void OnComplete()
    {
        Reset();
        MiniGameManager.MiniGameCompleted(this);
    }
}