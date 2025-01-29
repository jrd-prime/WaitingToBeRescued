using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Obj.InGame.Lootable
{
    [CreateAssetMenu(
        fileName = "newToolSettings",
        menuName = SOPathConst.InGameItem + "New Tool Settings",
        order = 100)]
    public class ToolSO : LootableItemSO<GameItemTypes.EToolItem>
    {
        public override int GetID() => Convert.ToInt32(itemId);

        public override void ShowDebug()
        {
            Debug.LogWarning("ToolSO / " + name);
        }
    }
}
