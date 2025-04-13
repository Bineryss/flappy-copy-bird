using System.Collections.Generic;
using UnityEngine;

public abstract class GameEventBase<T> : ScriptableObject
{
    private List<GameEventListenerBase<T>> listeners = new List<GameEventListenerBase<T>>();

    public void Raise(T data)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            Debug.Log(data);
            listeners[i].OnEventRaised(data);
        }
    }

    public void RegisterListener(GameEventListenerBase<T> listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventListenerBase<T> listener) => listeners.Remove(listener);
}
