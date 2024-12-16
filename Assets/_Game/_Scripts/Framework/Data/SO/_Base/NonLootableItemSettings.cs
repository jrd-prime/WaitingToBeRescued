using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace _Game._Scripts.Framework.Data.SO._Base
{
    public abstract class NonLootableItemSettingsBase : InGameObjectSettings
    {
    }

    public abstract class NonLootableItemSettings<TItemTypeEnum> : LootableItemSettingsBase
        where TItemTypeEnum : Enum
    {
        public TItemTypeEnum itemId;

        private void OnValidate()
        {
            if (EqualityComparer<TItemTypeEnum>.Default.Equals(itemId, default))
                throw new Exception($"Item type/id is not set. {name}");

            var newName = Convert.ToInt32(itemId) + "_" + Enum.GetName(typeof(TItemTypeEnum), itemId);

#if UNITY_EDITOR
            if (name == newName) return;
            name = newName;

            var assetPath = AssetDatabase.GetAssetPath(this);
            var assetDirectory = Path.GetDirectoryName(assetPath);
            var assetExtension = Path.GetExtension(assetPath);
            var newFilePath = $"{assetDirectory}/{newName}{assetExtension}";

            if (assetPath == newFilePath) return;
            AssetDatabase.RenameAsset(assetPath, newName);
            AssetDatabase.SaveAssets();
#endif
        }
    }
}
