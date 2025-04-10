using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private GameObject egg;
    [SerializeField] private float eggOffset = 5;
    [SerializeField] private float eggSpawnChance = 0.2f;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    private bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOver.on += handleGameOver;
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            spawnEgg();
            timer = 0;
        }
    }
    void OnDestroy()
    {
        GameOver.on -= handleGameOver;
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
    private void handleGameOver()
    {
        gameOver = true;
    }
    private void spawnEgg()
    {
        if (Random.value > eggSpawnChance) return;

        Instantiate(egg, new Vector3(transform.position.x + eggOffset, Random.Range(Camera.main.orthographicSize, -Camera.main.orthographicSize), 0), transform.rotation);
    }
}
