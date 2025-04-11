using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    private VisualElement root;
    private Label scoreLabel;
    private Label eggCountLabel;
    [SerializeField] private VisualTreeAsset gameModeUI;
    [SerializeField] private VisualTreeAsset gameOverUI;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        EggCollected.on += UpdateEggs;
        ScoreIncreased.on += UpdateScore;
        GameOver.on += handleGameOver;
    }

    private void OnDestroy()
    {
        EggCollected.on -= UpdateEggs;
        ScoreIncreased.on -= UpdateScore;
        GameOver.on -= handleGameOver;
    }
    private void OnEnable()
    {
        SwitchToGameMode();
    }
    private void UpdateEggs()
    {
        eggCountLabel.text = InventoryManager.instance.eggsCollected.ToString();
    }
    private void UpdateScore()
    {
        scoreLabel.text = GameManager.instance.score.ToString();
    }
    private void handleGameOver()
    {
        SwitchToGameOverMode();
    }

    public void SwitchToGameMode()
    {
        root.Clear();
        gameModeUI.CloneTree(root);
        scoreLabel = root.Q<Label>("score");
        eggCountLabel = root.Q<Label>("eggs");
        UpdateEggs();
    }

    public void SwitchToGameOverMode()
    {
        // Clear existing UI and load Game Over Mode UI
        root.Clear();
        gameOverUI.CloneTree(root);

        scoreLabel = root.Q<Label>("score");
        eggCountLabel = root.Q<Label>("eggs");
        UpdateEggs();
        UpdateScore();

        // Example: Add functionality to buttons in Game Over Mode
        var restartButton = root.Q<Button>("restart");
        restartButton.clicked += RestartGame;

        var mainMenuButton = root.Q<Button>("menu");
        mainMenuButton.clicked += GoToMainMenu;

        Debug.Log("Switched to Game Over Mode");
    }

    private void RestartGame()
    {
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GoToMainMenu()
    {
        Debug.Log("Going to Main Menu...");
        // Add logic to go back to the main menu
    }
}
