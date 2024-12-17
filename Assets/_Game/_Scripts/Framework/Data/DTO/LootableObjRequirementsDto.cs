using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Data.SO.Item.NonLootable;
using _Game._Scripts.Framework.Helpers;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.DTO
{
    [Serializable]
    public struct LootableObjRequirementsDto
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<BuildingSettings>> buildings;
        public List<CustomItemValue<SkillSettings>> skills;
        public List<CustomItemValue<ToolSettings>> tools;

        public void ShowDebug()
        {
            Debug.LogWarning("=== Requirements ===");
            resources.LogItems("Resource");
            buildings.LogItems("Building");
            skills.LogItems("Skill");
            tools.LogItems("Tool");
            Debug.LogWarning("===");
        }
    }
}
