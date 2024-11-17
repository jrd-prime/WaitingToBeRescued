#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace _Game._Scripts.Framework.Helpers.Editor
{
    [InitializeOnLoad]
    public class AutoPlayModeSceneSwitcher
    {
        private const string BootstrapScenePath = "Assets/Scenes/Bootstrap.unity";
        private const string LastEditedSceneKey = "LastEditedScene";

        static AutoPlayModeSceneSwitcher()
        {
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                SaveCurrentScene();
                SwitchToBootstrapScene();
            }
            else if (state == PlayModeStateChange.EnteredEditMode)
            {
                RestoreLastEditedScene();
            }
        }

        private static void SaveCurrentScene()
        {
            var activeScene = SceneManager.GetActiveScene();
            EditorPrefs.SetString(LastEditedSceneKey, activeScene.path);
            UnityEngine.Debug.Log($"Saved last edited scene: {activeScene.path}");
        }

        private static void SwitchToBootstrapScene()
        {
            var activeScene = SceneManager.GetActiveScene();
            if (activeScene.path != BootstrapScenePath)
            {
                UnityEngine.Debug.Log($"Switching to bootstrap scene: {BootstrapScenePath}");
                EditorSceneManager.OpenScene(BootstrapScenePath);
            }
        }

        private static void RestoreLastEditedScene()
        {
            var lastEditedScene = EditorPrefs.GetString(LastEditedSceneKey, string.Empty);
            if (!string.IsNullOrEmpty(lastEditedScene) && lastEditedScene != BootstrapScenePath)
            {
                UnityEngine.Debug.Log($"Restoring last edited scene: {lastEditedScene}");
                EditorSceneManager.OpenScene(lastEditedScene);
            }
            else
            {
                UnityEngine.Debug.Log("No last edited scene to restore.");
            }
        }
    }
}
#endif
