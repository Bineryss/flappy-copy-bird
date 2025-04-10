using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text eggsCollectedText;
    private void Start()
    {
        EggCollected.on += UpdateEggsUI;
        UpdateEggsUI();
    }

    private void OnDestroy()
    {
        EggCollected.on -= UpdateEggsUI;
    }

    private void UpdateEggsUI()
    {
        eggsCollectedText.text = InventoryManager.instance.eggsCollected.ToString();
    }
}
