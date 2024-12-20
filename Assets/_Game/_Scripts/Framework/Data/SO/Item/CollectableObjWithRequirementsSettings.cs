﻿using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "CollectableObjWithRequirements",
        menuName = SOPathConst.InGameItem + "New Collectable With Requirements Settings",
        order = 100)]
    public class CollectableObjWithRequirementsSettings : CollectableObjSettings
    {
        public CollectionConditionsData collectionConditions;

        public override void ShowDebug()
        {
            base.ShowDebug();
            Debug.LogWarning("=== Requirements ===");
            collectionConditions.resources.LogItems("Resource");
            collectionConditions.buildings.LogItems("Building");
            collectionConditions.skills.LogItems("Skill");
            collectionConditions.tools.LogItems("Tool");
            Debug.LogWarning("===");
        }
    }

    [Serializable]
    public struct CollectiblesData
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<ToolSettings>> tools;
        public List<CustomItemValue<StuffSettings>> stuff;

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
