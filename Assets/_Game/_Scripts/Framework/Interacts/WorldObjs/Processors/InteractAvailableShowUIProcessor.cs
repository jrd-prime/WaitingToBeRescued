using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsBehaviour;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings;
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
        public override void Process(InGameObjectSettings objSettings, EInteractState state)
        {
            if (objSettings is UsableSettings settings && state == EInteractState.EnoughForInteract)
            {
                Debug.LogWarning("ENOUGH FOR COLLECT UI INFO");
            }

            base.Process(objSettings, state);
        }
    }
}
