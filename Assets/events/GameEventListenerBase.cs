using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListenerBase<T> : MonoBehaviour
{
    [SerializeField] protected GameEventBase<T> gameEvent;
    [SerializeField] protected UnityEvent<T> onEventRaised;

    void OnEnable() => gameEvent.RegisterListener(this);
    void OnDisable() => gameEvent.UnregisterListener(this);
    public void OnEventRaised(T data) => onEventRaised.Invoke(data);
}