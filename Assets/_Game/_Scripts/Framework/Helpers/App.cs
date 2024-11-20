#if UNITY_EDITOR

using UnityEditor;

#else
using UnityEngine;
#endif

namespace _Game._Scripts.Framework.Helpers
{
    public static class App
    {
        public static void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
