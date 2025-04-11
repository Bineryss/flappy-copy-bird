using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent onEventTriggerd;


    private void OnEnable()
    {
        gameEvent.addListener(this);
    }

    private void OnDisable()
    {
        gameEvent.removeListener(this);
    }

    public void onEventTriggered()
    {
        onEventTriggerd.Invoke();
    }
}