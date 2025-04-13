using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialize : MonoBehaviour
{
    [SerializeField] private SceneReference mainMenu;
    void Awake()
    {
        if (string.IsNullOrEmpty(mainMenu.SceneName))
        {
            Debug.LogWarning("No scene has been assigned!");
            return;
        }
        SceneManager.LoadScene(mainMenu.SceneName, LoadSceneMode.Additive);
    }
}
