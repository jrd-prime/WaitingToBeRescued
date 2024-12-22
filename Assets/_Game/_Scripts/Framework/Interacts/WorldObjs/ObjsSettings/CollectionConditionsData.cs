using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Data.SO.Item.NonLootable;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings
{
    [Serializable]
    public struct CollectionConditionsData
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<BuildingSettings>> buildings;
        public List<CustomItemValue<SkillSettings>> skills;
        public List<CustomItemValue<ToolSettings>> tools;
    }
}
