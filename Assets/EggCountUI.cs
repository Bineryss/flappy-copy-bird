using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text eggsCollectedText;
    private void Start()
    {
        UI.onEggsCollectedChanged += UpdateEggsUI;
        UpdateEggsUI();
    }

    private void OnDestroy()
    {
        UI.onEggsCollectedChanged -= UpdateEggsUI;
    }

    private void UpdateEggsUI()
    {
        eggsCollectedText.text = InventoryManager.instance.eggsCollected.ToString();
    }
}
