using _Game._Scripts.Framework.Data.SO.Item;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj
{
    public struct InteractableObjWithConditionsDto : IInteractableWithConditions
    {
        public EInteract Interact { get; }

        public InteractableObjWithConditionsDto(InteractableObjWithRequirementsSettings settings)
        {
            Interact = settings.interact;
            Conditions = null;
        }

        public void ShowDebug()
        {
            Debug.LogWarning($"Interact: {Interact}");
            // Conditions.ShowDebug();
        }

        public CollectableObjWithRequirementsSettings Conditions { get; }
    }
}
