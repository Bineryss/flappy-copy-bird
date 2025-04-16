using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneHelper
{

    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private SceneReference startScene;
        [SerializeField] private SceneReference coreScene;
        void Awake()
        {
            if (string.IsNullOrEmpty(startScene.SceneName))
            {
                Debug.LogWarning("No scene has been assigned!");
                return;
            }
            StartCoroutine(LoadAndSetActiveScene(startScene.SceneName));
        }

        public void changeScene(string scene)
        {
            unLoadAllScenes();
            StartCoroutine(LoadAndSetActiveScene(scene));
        }

        private void unLoadAllScenes()
        {
            int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCount;
            Debug.Log(sceneCount);
            for (int i = 0; i < sceneCount; i++)
            {
                Scene current = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
                Debug.Log(current.name);
                if (!coreScene.SceneName.Equals(current.name))
                {
                    UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(current.name);
                }
            }
        }

        private IEnumerator LoadAndSetActiveScene(string sceneName)
        {
            // Start loading the scene additively
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // Wait until the scene is fully loaded
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            // Get a reference to the loaded scene
            Scene loadedScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName);

            // Ensure the scene is valid before setting it as active
            if (loadedScene.IsValid())
            {
                UnityEngine.SceneManagement.SceneManager.SetActiveScene(loadedScene);
                Debug.Log($"Active Scene set to: {loadedScene.name}");
            }
            else
            {
                Debug.LogError($"Failed to set active scene: {sceneName}");
            }
        }
    }
}