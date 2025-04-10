using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    private VisualElement ui;
    private Label scoreLabel;
    private Label eggCountLabel;
    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        EggCollected.on += UpdateEggs;
        ScoreIncreased.on += UpdateScore;
    }

    private void OnDestroy()
    {
        EggCollected.on -= UpdateEggs;
        ScoreIncreased.on -= UpdateScore;
    }

    private void OnEnable()
    {
        scoreLabel = ui.Q<Label>("score");
        eggCountLabel = ui.Q<Label>("eggs");
    }

    private void UpdateEggs()
    {
        eggCountLabel.text = InventoryManager.instance.eggsCollected.ToString();
    }
    private void UpdateScore()
    {
        scoreLabel.text = GameManager.instance.score.ToString();
    }
}
