using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateLevelScreen : MonoBehaviour
{
    private VisualElement root;
    [SerializeField] private VisualTreeAsset levelItemTemplate;
    [SerializeField] private List<LevelData> levels = new List<LevelData>();
    [SerializeField] private StringEvent onSceneChange;
    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("world-selection");
        foreach (LevelData level in levels)
        {
            root.Add(CreateLevelSelect(level));
        }
    }

    private VisualElement CreateLevelSelect(LevelData levelData)
    {
        VisualElement item = levelItemTemplate.CloneTree();
        item.Q<Label>("world-name").text = levelData.GetLevelName();

        VisualElement difficultyContainer = item.Q<VisualElement>("difficulty");
        List<VisualElement> starElements = difficultyContainer.Query<VisualElement>(className: "star-dark").ToList();
        changeStars(starElements, levelData.GetDifficulty());
        item.Q<Button>().clicked += () => onSceneChange.Raise(levelData.GetSceneName());
        return item;
    }

    private void changeStars(List<VisualElement> starElements, RewardChance difficulty)
    {
        int mappedDifficulty = 0;
        switch (difficulty)
        {
            case RewardChance.LOW:
                mappedDifficulty = 1;
                break;
            case RewardChance.MEDIUM:
                mappedDifficulty = 2;
                break;
            case RewardChance.HIGH:
                mappedDifficulty = 3;
                break;
        }

        for (int i = 0; i < mappedDifficulty; i++)
        {
            starElements[i].AddToClassList("star");
            starElements[i].RemoveFromClassList("star-dark");
        }
    }
}
