using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsBehaviour;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings;
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
        public override void Process(InGameObjectSettings objSettings, EInteractState state)
        {
            if (objSettings is UsableSettings settings && state == EInteractState.NotEnoughForInteract)
            {
                Debug.LogWarning("NOT ENOUGH FOR INTERACT UI INFO");
                return;
            }


            base.Process(objSettings, state);
        }
    }
}
