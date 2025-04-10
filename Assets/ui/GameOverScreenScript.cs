using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreenPrefab;
    [SerializeField] private LogicScript logicScript;
    void Start()
    {
        GameOver.on += handleGameOver;
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    void OnDestroy()
    {
        GameOver.on -= handleGameOver;
    }

    private void handleGameOver()
    {
        GameObject instance = Instantiate(gameOverScreenPrefab, gameObject.transform);
        instance.SetActive(true);
        Button restartButton = instance.GetComponentInChildren<Button>();
        restartButton.onClick.AddListener(() => logicScript.restartGame());
    }
}
