using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "Collectable",
        menuName = SOPathConst.InGameItem + "New Collectable Obj Settings",
        order = 100)]
    public class CollectableObjSettings : InGameObjectSettings
    {
        public LootableObjReturnsDto objReturnsDto;

        public override void ShowDebug()
        {
            objReturnsDto.ShowDebug();
        }
    }
}
