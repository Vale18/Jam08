using UnityEngine;

public class MiniGameScript : MonoBehaviour
{
    public virtual void OnStart()
    {
        
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