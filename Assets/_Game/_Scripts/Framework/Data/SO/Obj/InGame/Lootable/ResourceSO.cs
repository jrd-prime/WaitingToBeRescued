using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Obj.InGame.Lootable
{
    [CreateAssetMenu(
        fileName = "newResourceSettings",
        menuName = SOPathConst.InGameItem + "New Resource Settings",
        order = 100)]
    public class ResourceSO : LootableItemSO<GameItemTypes.EResourceItem>
    {
        public override int GetID() => Convert.ToInt32(itemId);

        public override void ShowDebug()
        {
            Debug.LogWarning("ResourceSO / " + name);
        }
    }
}
