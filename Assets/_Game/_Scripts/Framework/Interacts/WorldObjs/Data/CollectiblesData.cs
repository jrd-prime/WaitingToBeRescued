using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Obj.InGame.Lootable;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Data
{
    [Serializable]
    public struct CollectiblesData
    {
        public List<CustomItemValue<ResourceSO>> resources;
        public List<CustomItemValue<ToolSO>> tools;
        public List<CustomItemValue<StuffSO>> stuff;
    }
}
