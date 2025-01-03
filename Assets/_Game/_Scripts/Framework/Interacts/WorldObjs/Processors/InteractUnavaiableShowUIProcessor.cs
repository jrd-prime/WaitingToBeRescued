using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    internal class InteractUnavaiableShowUIProcessor : CharacterInteractProcessorBase
    {
        /// <summary>
        /// If conditions are not met, show conditions require UI
        /// </summary>
        [UsedImplicitly]
        public override void Process(InGameObjectSO objSO, EInteractState state)
        {
            if (objSO is UsableSO settings && state == EInteractState.NotEnoughForInteract)
            {
                Debug.LogWarning("NOT ENOUGH FOR INTERACT UI INFO");
                return;
            }


            base.Process(objSO, state);
        }
    }
}
