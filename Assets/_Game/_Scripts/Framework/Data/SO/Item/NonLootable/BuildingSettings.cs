using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.NonLootable
{
    [CreateAssetMenu(
        fileName = "newBuildingSettings",
        menuName = SOPathConst.InGameItem + "New Building Settings",
        order = 100)]
    public class BuildingSettings : NonLootableItemSettings
    {
        public override string ItemNameId => "Not Set";
    }
}
