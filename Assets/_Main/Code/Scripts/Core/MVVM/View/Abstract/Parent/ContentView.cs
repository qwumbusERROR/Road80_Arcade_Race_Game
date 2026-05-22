using System;
using UnityEngine;

public abstract class ContentView : MonoBehaviour, IDisposable
{
    public virtual void Initialize() { }
    public virtual void Dispose() { }
    protected virtual void OnDestroy()
    {
        Dispose();
    }
}
