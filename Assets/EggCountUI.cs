using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text eggsCollectedText;
    private void Start()
    {
        UI.EggsCollectedChanged += UpdateEggsUI;
    }

    private void OnDestroy()
    {
        UI.EggsCollectedChanged -= UpdateEggsUI;
    }

    private void UpdateEggsUI(int newEggCount)
    {
        eggsCollectedText.text = newEggCount.ToString();
    }
}
