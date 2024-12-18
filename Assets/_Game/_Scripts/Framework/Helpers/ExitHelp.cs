using UnityEngine;

namespace _Game._Scripts.Framework.Helpers
{
    //TODO remove
    public static class ExitHelp
    {
        public static void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
