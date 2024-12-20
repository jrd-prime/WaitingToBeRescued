using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interact.Character;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.DTO.InteractableObj
{
    public struct InteractableObjWithRequirementsDto : IInteracts, IRequirements
    {
        public EInteract Interact { get; }
        public LootableObjRequirementsDto Requirements { get; }

        public InteractableObjWithRequirementsDto(InteractableObjWithRequirementsSettings settings)
        {
            Interact = settings.interact;
            Requirements = settings.objRequirementsDto;
        }

        public void ShowDebug()
        {
            Debug.LogWarning($"Interact: {Interact}");
            Requirements.ShowDebug();
        }
    }
}
