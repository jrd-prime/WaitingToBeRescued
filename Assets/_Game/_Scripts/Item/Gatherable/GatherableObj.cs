using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Item._Base;
using _Game._Scripts.Item.Pickable;

namespace _Game._Scripts.Item.Gatherable
{
    public class GatherableObj : LootableItemObj<GatherableItemSystem, GatherableItemDto>
    {
        public List<CustomItemValue<ResourceSettings>> returns = new();
    }

}
