using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "CollectableObjWithRequirements",
        menuName = SOPathConst.InGameItem + "New Collectable With Requirements Settings",
        order = 100)]
    public class CollectableObjWithRequirementsSettings : CollectableObjSettings
    {
        public LootableObjRequirementsDto objRequirementsDto;

        public override void ShowDebug()
        {
            base.ShowDebug();
            objRequirementsDto.ShowDebug();
        }
    }
}
