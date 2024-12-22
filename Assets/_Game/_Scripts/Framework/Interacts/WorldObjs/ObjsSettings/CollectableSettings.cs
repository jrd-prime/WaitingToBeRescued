using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item._Base;
using _Game._Scripts.Framework.Helpers;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings
{
    [CreateAssetMenu(
        fileName = "Collectable",
        menuName = SOPathConst.InWorldItem + "New Collectable",
        order = 100)]
    public class CollectableSettings : InGameObjectSettings
    {
        public CollectiblesData collectibles;

        public override void ShowDebug()
        {
            Debug.LogWarning("=== Returns ===");
            collectibles.resources.LogItems("Resource");
            collectibles.tools.LogItems("Tool");
            collectibles.stuff.LogItems("Stuff");
            Debug.LogWarning("===");
        }

        public Dictionary<int, float> GetCollectiblesWithId()
        {
            var dict = new Dictionary<int, float>();

            foreach (var item in collectibles.resources) dict.TryAdd((int)item.itemSettings.itemId, item.value);
            foreach (var item in collectibles.tools) dict.TryAdd((int)item.itemSettings.itemId, item.value);
            foreach (var item in collectibles.stuff) dict.TryAdd((int)item.itemSettings.itemId, item.value);

            return dict;
        }

        public Dictionary<LootableItemSettingsBase, float> GetCollectiblesWithSettings()
        {
            var dict = new Dictionary<LootableItemSettingsBase, float>();

            foreach (var item in collectibles.resources) dict.TryAdd(item.itemSettings, item.value);
            foreach (var item in collectibles.tools) dict.TryAdd(item.itemSettings, item.value);
            foreach (var item in collectibles.stuff) dict.TryAdd(item.itemSettings, item.value);

            return dict;
        }
    }
}
