using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    [SerializeField] private Rigidbody2D birdBody;
    [SerializeField] private CircleCollider2D birdBox;
    [SerializeField] private float torqueAmount = 5;
    [SerializeField] private GameEvent onPlayerDeath;

    void OnCollisionEnter2D(Collision2D collision)
    {
        onPlayerDeath.triggerEvent();
    }

    public void handleGameOver()
    {
        birdBody.AddTorque(torqueAmount, ForceMode2D.Impulse);
        birdBox.enabled = false;
    }
}
