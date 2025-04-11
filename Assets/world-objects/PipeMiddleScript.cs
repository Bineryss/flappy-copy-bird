using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    [SerializeField] private GameEvent onScoreIncreased;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 3) return;
        onScoreIncreased.triggerEvent();
    }
}
