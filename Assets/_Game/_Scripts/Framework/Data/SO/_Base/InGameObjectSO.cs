using UnityEngine;
#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
#endif

namespace _Game._Scripts.Framework.Data.SO._Base
{
    public abstract class InGameObjectSO : SettingsSO
    {
        public Sprite icon;
        public abstract void ShowDebug();

#if UNITY_EDITOR
        protected void RenameAsset(Enum itemId)
        {
            var newName = Convert.ToInt32(itemId) + "_" + Enum.GetName(itemId.GetType(), itemId);

            if (name == newName) return;
            name = newName;

            var assetPath = AssetDatabase.GetAssetPath(this);
            var assetDirectory = Path.GetDirectoryName(assetPath);
            var assetExtension = Path.GetExtension(assetPath);
            var newFilePath = $"{assetDirectory}/{newName}{assetExtension}";

            if (assetPath == newFilePath) return;
            AssetDatabase.RenameAsset(assetPath, newName);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}
