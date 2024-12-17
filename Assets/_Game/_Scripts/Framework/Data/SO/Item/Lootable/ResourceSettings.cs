using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.Lootable
{
    [CreateAssetMenu(
        fileName = "newResourceSettings",
        menuName = SOPathConst.InGameItem + "New Resource Settings",
        order = 100)]
    public class ResourceSettings : LootableItemSettings<GameItemTypes.EResourceItem>
    {

        public override void ShowDebug()
        {
            Debug.LogWarning("ResourceSettings / " + name);
        }
    }
}
