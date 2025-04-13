using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialize : MonoBehaviour
{
    [SerializeField] private SceneReference mainMenu;
    [SerializeField] private SceneReference coreScene;
    void Awake()
    {
        if (string.IsNullOrEmpty(mainMenu.SceneName))
        {
            Debug.LogWarning("No scene has been assigned!");
            return;
        }
        StartCoroutine(LoadAndSetActiveScene(mainMenu.SceneName));
    }

    public void changeScene(string scene)
    {
        unLoadAllScenes();
        StartCoroutine(LoadAndSetActiveScene(scene));
    }

    private void unLoadAllScenes()
    {
        int sceneCount = SceneManager.sceneCount;
        Debug.Log(sceneCount);
        for (int i = 0; i < sceneCount; i++)
        {
            Scene current = SceneManager.GetSceneAt(i);
            Debug.Log(current.name);
            if (!coreScene.SceneName.Equals(current.name))
            {
                SceneManager.UnloadSceneAsync(current.name);
            }
        }
    }

    private IEnumerator LoadAndSetActiveScene(string sceneName)
    {
        // Start loading the scene additively
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Get a reference to the loaded scene
        Scene loadedScene = SceneManager.GetSceneByName(sceneName);

        // Ensure the scene is valid before setting it as active
        if (loadedScene.IsValid())
        {
            SceneManager.SetActiveScene(loadedScene);
            Debug.Log($"Active Scene set to: {loadedScene.name}");
        }
        else
        {
            Debug.LogError($"Failed to set active scene: {sceneName}");
        }
    }
}
