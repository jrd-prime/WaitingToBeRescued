using _Game._Scripts.Framework.Data.SO.Item;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj
{
    public struct InteractableObjDto : IInteractable
    {
        public EInteract Interact { get; }

        public InteractableObjDto(InteractableObjSettings settings)
        {
            Interact = settings.interact;
        }

        public void ShowDebug()
        {
            Debug.LogWarning($"Interact: {Interact}");
        }
    }
}
