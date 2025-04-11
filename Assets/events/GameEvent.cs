using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Objects/GameEvent")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void triggerEvent()
    {
        foreach (GameEventListener listener in listeners)
        {
            listener.onEventTriggered();
        }
    }

    public void addListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void removeListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
