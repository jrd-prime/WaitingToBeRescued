using System.IO;
using _Game._Scripts.Framework.Data.Constants;
using UnityEditor;
using UnityEngine;

namespace _Game._Scripts.Framework.Helpers.Editor
{
    public class DeleteSavesMenu
    {
#if UNITY_EDITOR
        [MenuItem("Game Tools/Delete saves")]
#endif
        public static void DeleteSaves()
        {
            var directory = JPath.SavePath;
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files) File.Delete(file);

                UnityEngine.Debug.LogWarning("All saves deleted.");
            }
            else UnityEngine.Debug.LogWarning($"Directory {directory} not exists.");
        }
#if UNITY_EDITOR
        [MenuItem("Game Tools/Reset Settings", true)]
        private static bool ValidateDeleteSaves() => Application.isPlaying == false;
#endif
    }
}
