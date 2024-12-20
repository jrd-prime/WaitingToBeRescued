using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Interact.Character._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interact.Character.Processors
{
    [UsedImplicitly]
    public class ConditionInteractionProcessor : CharacterInteractProcessorBase
    {
        public override void Process(IInteractObjectDto objDto)
        {
            if (objDto is CollectableObjWithRequirementsDto)
            {
                Debug.LogWarning("obj is Gatherable!!");
            }

            base.Process(objDto);
        }
    }
}
