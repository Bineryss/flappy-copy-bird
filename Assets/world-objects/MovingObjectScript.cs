using UnityEngine;

public class MovingObjectScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float deadZoneOffset = 5;
    private float deadZone;
    private bool freez;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOver.on += handleGameOver;
        deadZone = (Camera.main.orthographicSize * Camera.main.aspect + deadZoneOffset) * -1;
    }
    void OnDestroy()
    {
        GameOver.on -= handleGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (freez) return;
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("moving object deleted");
            Destroy(gameObject);
        }
    }

    private void handleGameOver()
    {
        freez = true;
    }
}
