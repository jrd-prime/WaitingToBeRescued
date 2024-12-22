using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsBehaviour;
using _Game._Scripts.Item._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class UseWithConditionProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSettings objSettings, EInteractState interactState)
        {
            // if (objSettings is InteractableObjWithConditionsDto)
            // {
            //     Debug.LogWarning("Interact With Condition Processor");
            //     Debug.LogWarning("obj is Gatherable!!");
            // }

            base.Process(objSettings, interactState);
        }
    }
}
