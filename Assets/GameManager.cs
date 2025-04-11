using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] public float score { get; private set; }
    [SerializeField] private float baseSpeed;
    [SerializeField] private float speedMultiplyer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float getCurrentSpeed()
    {
        return baseSpeed + score * speedMultiplyer;
    }

    [ContextMenu("Increase Score")]

    public void addScore(int amount = 1)
    {
        score += amount;
    }

}
