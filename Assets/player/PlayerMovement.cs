using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float flapStrength = 5;
    [SerializeField] private Rigidbody2D playerBody;
    private bool dead;
    public void onFlap(InputAction.CallbackContext context)
    {
        if (dead)
        {
            return;
        }
        playerBody.linearVelocity = Vector2.up * flapStrength;
    }

    void Start()
    {
        GameOver.on += handleGameOver;

    }
    void OnDestroy()
    {
        GameOver.on -= handleGameOver;
    }

    public void handleGameOver()
    {
        dead = true;
    }
}
