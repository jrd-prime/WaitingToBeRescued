using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Item
{
    [CreateAssetMenu(
        fileName = "Interactable",
        menuName = SOPathConst.InGameItem + "New Interactable Obj Settings",
        order = 100)]
    public class InteractableObjSettings : InGameObjectSettings
    {
        public EInteract interact;

        public override void ShowDebug()
        {
            Debug.LogWarning($"Interact: {interact}");
        }
    }
}
