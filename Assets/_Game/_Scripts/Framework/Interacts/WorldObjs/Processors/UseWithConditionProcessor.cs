using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Item._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class UseWithConditionProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            // if (objSO is InteractableObjWithConditionsDto)
            // {
            //     Debug.LogWarning("Interact With Condition Processor");
            //     Debug.LogWarning("obj is Gatherable!!");
            // }

            base.Process(objSO, interactState);
        }
    }
}
