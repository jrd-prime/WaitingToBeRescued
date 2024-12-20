using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "InteractableWithRequirements",
        menuName = SOPathConst.InGameItem + "New Interactable With Requirements Obj Settings",
        order = 100)]
    public class InteractableObjWithRequirementsSettings : InteractableObjSettings
    {
        public LootableObjRequirementsDto objRequirementsDto;

        public override void ShowDebug()
        {
            base.ShowDebug();
            objRequirementsDto.ShowDebug();
        }
    }
}
