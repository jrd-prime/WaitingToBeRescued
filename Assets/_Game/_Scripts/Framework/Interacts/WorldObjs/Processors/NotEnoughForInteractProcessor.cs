using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using UnityEngine;

namespace _Game._Scripts.Item._Base
{
    internal class NotEnoughForInteractProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSettings objSettings, EInteractState state)
        {
            if (objSettings is InteractableObjSettings settings && state == EInteractState.NotEnoughForInteract)
            {
                Debug.LogWarning("NOT ENOUGH FOR INTERACT UI INFO");
                return;
            }


            base.Process(objSettings, state);
        }
    }
}
