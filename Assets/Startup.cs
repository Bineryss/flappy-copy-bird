using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pipeSpawner;
    [SerializeField] private int objectSpawnerOffset = 5;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject ui;
    void Awake()
    {
        Instantiate(player);
        Instantiate(ui);
        Invoke("placeObjectSpawner", 0.1f);
    }

    private void placeObjectSpawner()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Main Camera not found!");
            return;
        }

        // Calculate width using orthographicSize and aspect ratio.
        float cameraWidth = cam.orthographicSize * cam.aspect;
        Debug.Log("Camera width (using orthographic values): " + cameraWidth);

        Instantiate(pipeSpawner, new Vector3(cameraWidth + objectSpawnerOffset, 0, 0), pipeSpawner.transform.rotation);
    }
}
