using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.Lootable
{
    [CreateAssetMenu(
        fileName = "newStuffSettings",
        menuName = SOPathConst.InGameItem + "New Stuff Settings",
        order = 100)]
    public class StuffSettings : LootableItemSettings
    {
        public override string ItemNameId => "Not Set";
    }
}
