﻿using _Game._Scripts.Framework.Data.SO.Obj.InWorld;
using _Game._Scripts.Framework.Interacts.Processors._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game._Scripts.Framework.Interacts.Processors
{
    /// <summary>
    /// If conditions are met, show use UI
    /// </summary>
    [UsedImplicitly]
    public class UseUIProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Use UI Processor";

        public override void Process(InWorldObjectSO objSO, EInteractState interactState)
        {
            if (objSO is UsableSO settings)
            {
                if (interactState == EInteractState.EnoughForUse)
                {
                    Debug.LogWarning("SHOW UI - ENOUGH FOR USE");
                }
                else if (interactState == EInteractState.NotEnoughForUse)
                {
                    Debug.LogWarning("SHOW UI - NOT ENOUGH FOR USE");
                }
            }

            base.Process(objSO, interactState);
        }
    }
}
