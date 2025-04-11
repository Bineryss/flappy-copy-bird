using UnityEngine;

public class MovingObjectScript : MonoBehaviour
{
    [SerializeField] private float deadZoneOffset = 5;
    private float deadZone;
    private bool freez;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deadZone = (Camera.main.orthographicSize * Camera.main.aspect + deadZoneOffset) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (freez) return;
        transform.position = transform.position + Vector3.left * GameManager.instance.getCurrentSpeed() * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("moving object deleted");
            Destroy(gameObject);
        }
    }

    public void handleGameOver()
    {
        freez = true;
    }
}
