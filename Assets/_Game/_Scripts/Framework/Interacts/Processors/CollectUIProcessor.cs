using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interacts.Processors._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using _Game._Scripts.Player.HUD;
using JetBrains.Annotations;
using R3;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.Processors
{
    /// <summary>
    /// If conditions are met, show collect UI
    /// </summary>
    [UsedImplicitly]
    public class CollectUIProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Collect UI Processor";

        private CharacterHUDManager _characterHUDManager;

        [Inject]
        private void Construct(CharacterHUDManager characterHUDManager)
        {
            _characterHUDManager = characterHUDManager;
        }

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (objSO is CollectableSO settings)
            {
                if (interactState == EInteractState.EnoughForCollect)
                {
                    Debug.LogWarning("COLLECT UI - ENOUGH");

                    Optional<CharacterHUDManager>.Some(_characterHUDManager)
                        .Match(
                            manager =>
                            {
                                var collectiblesWithSettings = settings.GetCollectiblesWithSettings();
                                manager.NewObjToBackpackAsync(collectiblesWithSettings);
                                return Unit.Default;
                            },
                            () => throw new NullReferenceException("CharacterHUDManager is null"));
                }
                else if (interactState == EInteractState.NotEnoughForCollect)
                {
                    Debug.LogWarning("COLLECT UI - NOT ENOUGH");
                }
            }

            base.Process(objSO, interactState);
        }
    }
}
