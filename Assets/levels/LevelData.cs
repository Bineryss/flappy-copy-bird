using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private string levelName;
    [SerializeField] private RewardChance difficulty;
    [SerializeField] private RewardChance rewardChance;
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplyer;
    [SerializeField] private float pipeSpawnRate;
    [SerializeField] private float eggSpawnRate;

    public string GetLevelName()
    {
        return levelName;
    }

    public RewardChance GetDifficulty()
    {
        return difficulty;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetSpeedMultiplyer()
    {
        return speedMultiplyer;
    }

    public float GetPipeSpawnrate()
    {
        return pipeSpawnRate;
    }

    public float GetEggSpawnRate()
    {
        return eggSpawnRate;
    }
}

public enum RewardChance
{
    HIGH,
    MEDIUM,
    LOW
}
