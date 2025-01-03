using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Settings
{
    [CreateAssetMenu(
        fileName = "CollectableObjWithConditions",
        menuName = SOPathConst.InWorldItem + "New Collectable With Conditions",
        order = 100)]
    public class CollectableWithConditionsSO : CollectableSO
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
        public List<CustomItemValue<ResourceSO>> resources;
        public List<CustomItemValue<ToolSO>> tools;
        public List<CustomItemValue<StuffSO>> stuff;

     

       
    }
}
