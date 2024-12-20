using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class InteractWithConditionProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSettings objDto)
        {
            if (objDto is InteractableObjWithConditionsDto)
            {
                Debug.LogWarning("Interact With Condition Processor");
                Debug.LogWarning("obj is Gatherable!!");
            }

            base.Process(objDto);
        }
    }
}
