using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    /// <summary>
    /// If conditions are met, show use UI
    /// </summary>
    [UsedImplicitly]
    public class InteractAvailableShowUIProcessor : CharacterInteractProcessorBase
    {
        public override void Process(InGameObjectSO objSO, EInteractState state)
        {
            if (objSO is UsableSO settings && state == EInteractState.EnoughForInteract)
            {
                Debug.LogWarning("ENOUGH FOR COLLECT UI INFO");
            }

            base.Process(objSO, state);
        }
    }
}
