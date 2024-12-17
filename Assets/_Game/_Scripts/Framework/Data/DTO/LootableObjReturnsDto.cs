using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Helpers;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.DTO
{
    [Serializable]
    public struct LootableObjReturnsDto
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<ToolSettings>> tools;
        public List<CustomItemValue<StuffSettings>> stuff;

        public void ShowDebug()
        {
            Debug.LogWarning("=== Returns ===");
            resources.LogItems("Resource");
            tools.LogItems("Tool");
            stuff.LogItems("Stuff");
            Debug.LogWarning("===");
        }

        public Dictionary<int, float> GetAllItems()
        {
            var dict = new Dictionary<int, float>();

            foreach (var item in resources) dict.TryAdd((int)item.itemSettings.itemId, item.value);
            foreach (var item in tools) dict.TryAdd((int)item.itemSettings.itemId, item.value);
            foreach (var item in stuff) dict.TryAdd((int)item.itemSettings.itemId, item.value);

            return dict;
        }
    }
}
