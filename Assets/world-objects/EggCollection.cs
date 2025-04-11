using UnityEngine;

public class EggCollection : MonoBehaviour
{
    [SerializeField] private GameEvent onCollect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("player")) return;
        onCollect.triggerEvent();
        gameObject.SetActive(false);
        //TODO trigger animation
    }
}
