using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pipeSpawner;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float cameraRightBorder = mainCamera.orthographicSize * mainCamera.aspect;
        Instantiate(ui);
        Instantiate(player);
        Instantiate(pipeSpawner, new Vector3(cameraRightBorder + 5, 0, 0), pipeSpawner.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
