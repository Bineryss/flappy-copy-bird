using UnityEngine;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    private int score; // Runtime score (doesn't need to persist)
    [SerializeField] public int eggsCollected { get; private set; }

    private string savePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
            savePath = Application.persistentDataPath + "/save-data.json";
            LoadGame(); // Load data when the game starts
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
        EggCollected.trigger();
    }

    public void AddEgg()
    {
        eggsCollected++;
        EggCollected.trigger();
        Debug.Log("Eggs Collected: " + eggsCollected);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    public void SaveGame()
    {
        SaveData data = new SaveData { eggsCollected = eggsCollected };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            eggsCollected = data.eggsCollected;
            Debug.Log("Game Loaded! Eggs Collected: " + eggsCollected);
        }
        else
        {
            Debug.LogWarning("No save file found. Starting fresh.");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int eggsCollected;
}
