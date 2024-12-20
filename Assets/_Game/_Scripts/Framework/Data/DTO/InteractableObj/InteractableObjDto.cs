using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interact.Character;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.DTO.InteractableObj
{
    public struct InteractableObjDto : IInteracts
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
