using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs;
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
