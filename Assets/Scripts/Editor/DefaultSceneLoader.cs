#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

/// <summary>
/// Default scene loader.
/// </summary>
/// <description>
/// This class adds a Utils > Scene Autoload menu containing options to select
/// a "default scene" enable it to be auto-loaded when the user presses play
/// in the editor. When enabled, the selected scene will be loaded on play,
/// then the original scene will be reloaded on stop.
///
/// Based on an idea on this thread:
/// http://forum.unity3d.com/threads/157502-Executing-first-scene-in-build-settings-when-pressing-play-button-in-editor
/// </description>
[InitializeOnLoadAttribute]
public static class DefaultSceneLoader
{
    static DefaultSceneLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    // Menu items to select the "Default" scene and control whether or not to load it.
    [MenuItem("Utils/Scene Autoload/Select Default Scene...")]
    private static void SelectDefaultScene()
    {
        string defaultScene = EditorUtility.OpenFilePanel("Select Default Scene", Application.dataPath, "unity");
        defaultScene = defaultScene.Replace(Application.dataPath, "Assets"); //project relative instead of absolute path
        if (!string.IsNullOrEmpty(defaultScene))
        {
            DefaultScene = defaultScene;
            LoadDefaultOnPlay = true;
        }
    }

    [MenuItem("Utils/Scene Autoload/Load Default On Play", true)]
    private static bool ShowLoadDefaultOnPlay()
    {
        return !LoadDefaultOnPlay;
    }

    [MenuItem("Utils/Scene Autoload/Load Default On Play")]
    private static void EnableLoadDefaultOnPlay()
    {
        LoadDefaultOnPlay = true;
    }

    [MenuItem("Utils/Scene Autoload/Don't Load Default On Play", true)]
    private static bool ShowDontLoadDefaultOnPlay()
    {
        return LoadDefaultOnPlay;
    }

    [MenuItem("Utils/Scene Autoload/Don't Load Default On Play")]
    private static void DisableLoadDefaultOnPlay()
    {
        LoadDefaultOnPlay = false;
    }

    // Play mode change callback handles the scene load/reload.
    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (!LoadDefaultOnPlay)
        {
            return;
        }

        if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
        {
            // User pressed play -- autoload default scene.
            PreviousScene = EditorSceneManager.GetActiveScene().path;
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                try
                {
                    EditorSceneManager.OpenScene(DefaultScene);
                }
                catch
                {
                    Debug.LogError(string.Format("Error: Scene not found: {0}", DefaultScene));
                    EditorApplication.isPlaying = false;
                }
            }
            else
            {
                // User cancelled the save operation -- cancel play as well.
                EditorApplication.isPlaying = false;
            }
        }

        // isPlaying check required because cannot OpenScene while playing
        if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            // User pressed stop -- reload previous scene.
            try
            {
                EditorSceneManager.OpenScene(PreviousScene);
            }
            catch
            {
                Debug.LogError(string.Format("Error: Scene not found: {0}", PreviousScene));
            }
        }
    }

    // Properties are remembered as editor preferences.
    private const string EDITOR_PREF_LOAD_DEFAULT_ON_PLAY = "SceneAutoLoader.LoadDefaultOnPlay";
    private const string EDITOR_PREF_DEFAULT_SCENE = "SceneAutoLoader.DefaultScene";
    private const string EDITOR_PREF_PREVIOUS_SCENE = "SceneAutoLoader.PreviousScene";

    private static bool LoadDefaultOnPlay
    {
        get { return EditorPrefs.GetBool(EDITOR_PREF_LOAD_DEFAULT_ON_PLAY, false); }
        set { EditorPrefs.SetBool(EDITOR_PREF_LOAD_DEFAULT_ON_PLAY, value); }
    }

    private static string DefaultScene
    {
        get { return EditorPrefs.GetString(EDITOR_PREF_DEFAULT_SCENE, "Default.unity"); }
        set { EditorPrefs.SetString(EDITOR_PREF_DEFAULT_SCENE, value); }
    }

    private static string PreviousScene
    {
        get { return EditorPrefs.GetString(EDITOR_PREF_PREVIOUS_SCENE, EditorSceneManager.GetActiveScene().path); }
        set { EditorPrefs.SetString(EDITOR_PREF_PREVIOUS_SCENE, value); }
    }
}
#endif
