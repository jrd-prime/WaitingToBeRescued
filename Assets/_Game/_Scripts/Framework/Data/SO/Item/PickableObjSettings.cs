using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "newPickableObjSettings",
        menuName = SOPathConst.InGameItem + "New Pickable Obj Settings",
        order = 100)]
    public class PickableObjSettings : InGameObjectSettings
    {
        [FormerlySerializedAs("objReturnsData")] [FormerlySerializedAs("objReturns")] public LootableObjReturnsDto objReturnsDto;

        public override void ShowDebug()
        {
            Debug.LogWarning("PickableObjSettings / " + name);
        }
    }
}
