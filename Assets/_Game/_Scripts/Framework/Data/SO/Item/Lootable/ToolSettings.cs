using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.Lootable
{
    [CreateAssetMenu(
        fileName = "newToolSettings",
        menuName = SOPathConst.InGameItem + "New Tool Settings",
        order = 100)]
    public class ToolSettings : LootableItemSettings<GameItemTypes.EToolItem>
    {
    }
}
