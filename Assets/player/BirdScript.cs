using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D birdBody;
    [SerializeField]
    private CircleCollider2D birdBox;
    [SerializeField] private float torqueAmount = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOver.on += handleGameOver;

    }
    void OnDestroy()
    {
        GameOver.on -= handleGameOver;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        birdBody.AddTorque(torqueAmount, ForceMode2D.Impulse);
        GameOver.trigger();
    }

    public void handleGameOver()
    {
        dead = true;
        birdBox.enabled = false;
    }
}
