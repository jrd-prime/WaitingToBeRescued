using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class CollectWithConditionProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSettings objDto)
        {
            if (objDto is CollectableWithConditionsDto)
            {
                Debug.LogWarning("Collect With Condition Processor");
                Debug.LogWarning("obj is Gatherable!!");
            }

            base.Process(objDto);
        }
    }
}
