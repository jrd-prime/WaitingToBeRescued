using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Data.SO.Item.NonLootable;

namespace _Game._Scripts.Framework.Data.DTO
{
    [Serializable]
    public struct LootableObjRequirementsDto
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<BuildingSettings>> buildings;
        public List<CustomItemValue<SkillSettings>> skills;
        public List<CustomItemValue<ToolSettings>> tools;
    }
}
