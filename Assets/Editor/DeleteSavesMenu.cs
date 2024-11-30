using System.IO;
using _Game._Scripts.Framework.Data.Constants;
using UnityEditor;
using UnityEngine;

namespace _Game._Scripts.Editor
{
    public class DeleteSavesMenu
    {
        [MenuItem("Game Tools/Delete saves")]
        private static void DeleteSaves()
        {
            var directory = JPath.SavePath;
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files) File.Delete(file);

                Debug.LogWarning("All saves deleted.");
            }
            else Debug.LogWarning($"Directory {directory} not exists.");
        }

        [MenuItem("Game Tools/Reset Settings", true)]
        private static bool ValidateDeleteSaves() => Application.isPlaying == false;
    }
}
