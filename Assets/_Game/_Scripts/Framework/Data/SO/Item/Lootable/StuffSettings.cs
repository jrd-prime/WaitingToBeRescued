using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.Lootable
{
    [CreateAssetMenu(
        fileName = "newStuffSettings",
        menuName = SOPathConst.InGameItem + "New Stuff Settings",
        order = 100)]
    public class StuffSettings : LootableItemSettings<GameItemTypes.EStuffItem>
    {
        public override void ShowDebug()
        {
            Debug.LogWarning("StuffSettings / " + name);
        }
    }
}
