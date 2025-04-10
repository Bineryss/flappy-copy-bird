using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    [SerializeField]
    private int playerScore = 0;
    [SerializeField]
    private BoxCollider2D deathBoundary;
    [SerializeField]
    private Camera mainCamera;
    public TMP_Text scoreText;


    void Start()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        deathBoundary.size = new Vector2(cameraWidth, cameraHeight);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
