using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// A helper class that stores a reference to a scene using a SceneAsset (editor only)
/// and also saves its path as a string for runtime use.
/// </summary>
[System.Serializable]
public class SceneReference
{
    // This field is only available in the editor.
#if UNITY_EDITOR
    [SerializeField]
    private SceneAsset sceneAsset;
#endif

    private string scenePath = "";

    /// <summary>
    /// Gets the full path of the scene asset.
    /// In the editor, this field gets updated automatically.
    /// </summary>
    public string ScenePath
    {
        get
        {
#if UNITY_EDITOR
            // If the scene asset is assigned, update the path.
            if (sceneAsset != null)
            {
                scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            }
#endif
            return scenePath;
        }
    }

    /// <summary>
    /// Returns just the scene's name (i.e. without folder path and extension).
    /// This is what you can pass to SceneManager.LoadScene.
    /// </summary>
    public string SceneName
    {
        get
        {
            string path = ScenePath;
            int slashIndex = path.LastIndexOf('/') + 1;
            int dotIndex = path.LastIndexOf('.');
            return path.Substring(slashIndex, dotIndex - slashIndex);
        }
    }
}

/// <summary>
/// Example MonoBehaviour that uses the SceneReference.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // You can now drag a scene asset to this field in the Inspector.
    public SceneReference sceneReference;

    /// <summary>
    /// Load the scene using its name extracted from the scene asset.
    /// </summary>
    public void LoadScene()
    {
        string sceneName = sceneReference.SceneName;
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("No scene has been assigned!");
        }
    }
}
