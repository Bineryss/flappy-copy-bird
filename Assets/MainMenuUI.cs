using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    private VisualElement root;
    private VisualElement startScreen;
    private VisualElement levelScreen;
    private Button backButton;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startScreen = root.Q<VisualElement>("start-screen");
        levelScreen = root.Q<VisualElement>("world-selection");
        backButton = root.Q<Button>("back");
        backButton.clicked += displayStartScreen;

        Button playButton = root.Q<Button>("play");
        playButton.clicked += handelStart;
        Button levelSelection = root.Q<Button>("level-select");
        levelSelection.clicked += handelLevelScreen;
        root.Q<Button>("world_play").clicked += handelStart;
    }

    private void handelStart()
    {
        SceneManager.LoadScene("GameScene");
    }


    private void handelLevelScreen()
    {
        startScreen.AddToClassList("hidden");
        levelScreen.RemoveFromClassList("hidden");
        backButton.RemoveFromClassList("hidden");
    }
    private void displayStartScreen()
    {
        startScreen.RemoveFromClassList("hidden");
        levelScreen.AddToClassList("hidden");
        backButton.AddToClassList("hidden");
    }
}
