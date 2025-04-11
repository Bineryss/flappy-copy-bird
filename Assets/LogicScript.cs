using UnityEngine;
public class LogicScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D deathBoundary;
    [SerializeField] private Camera mainCamera;


    void Start()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        deathBoundary.size = new Vector2(cameraWidth, cameraHeight);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        if (collision.tag == "player")
        {
            Debug.Log("Player collision detected");
            GameOver.trigger();
        }
    }
}
