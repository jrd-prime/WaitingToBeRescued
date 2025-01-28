﻿using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Data.SO.Item.NonLootable;
using _Game._Scripts.Framework.Helpers;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Data
{
    [Serializable]
    public struct UsingConditionsData
    {
        public List<CustomItemValue<ResourceSO>> resources;
        public List<CustomItemValue<BuildingSO>> buildings;
        public List<CustomItemValue<SkillSO>> skills;
        public List<CustomItemValue<ToolSO>> tools;

        public void ShowDebug()
        {
            Debug.LogWarning("=== Use Requirements ===");
            resources.LogItems("Resource");
            buildings.LogItems("Building");
            skills.LogItems("Skill");
            tools.LogItems("Tool");
            Debug.LogWarning("===");
        }
    }
}
