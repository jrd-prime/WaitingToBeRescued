using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Item._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item.NonLootable
{
    [CreateAssetMenu(
        fileName = "newBuildingSettings",
        menuName = SOPathConst.InGameItem + "New Building Settings",
        order = 100)]
    public class BuildingSO : NonLootableItemSO<GameItemTypes.EBuildingItem>
    {
        public override void ShowDebug()
        {
            Debug.LogWarning("BuildingSO / " + name);
        }
    }
}
