using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Data.SO.Item.NonLootable;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Data
{
    [Serializable]
    public struct UsingConditionsData
    {
        public List<CustomItemValue<ResourceSO>> resources;
        public List<CustomItemValue<BuildingSO>> buildings;
        public List<CustomItemValue<SkillSO>> skills;
        public List<CustomItemValue<ToolSO>> tools;
    }
}
