using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Item.Pickable;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "newGatherableObjSettings",
        menuName = SOPathConst.InGameItem + "New Gatherable Obj Settings",
        order = 100)]
    public class GatherableObjSettings : InGameObjectSettings
    {
        public LootableObjReturns objReturns;
    }
}
