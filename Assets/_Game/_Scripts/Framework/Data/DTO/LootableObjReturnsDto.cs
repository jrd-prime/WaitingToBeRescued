using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;

namespace _Game._Scripts.Framework.Data.DTO
{
    [Serializable]
    public struct LootableObjReturnsDto
    {
        public List<CustomItemValue<ResourceSettings>> resources;
        public List<CustomItemValue<ToolSettings>> tools;
        public List<CustomItemValue<StuffSettings>> stuff;
    }
}
