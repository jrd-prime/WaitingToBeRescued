using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Item._Base;
using _Game._Scripts.Player.HUD;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class EnoughForCollectUIInfoProcessor : CharacterInteractProcessorBase
    {
        private CharacterHUDManager _characterHUDManager;

        [Inject]
        private void Construct(CharacterHUDManager characterHUDManager)
        {
            _characterHUDManager = characterHUDManager;
        }

        public override void Process(InGameObjectSettings objSettings, EInteractState interactState)
        {
            if (_characterHUDManager == null) throw new NullReferenceException("CharHud is null");

            if (objSettings is CollectableObjSettings settings && interactState == EInteractState.EnoughForCollect)
            {
                Debug.LogWarning("ENOUGH FOR COLLECT UI INFO");
                Debug.LogWarning("ShowCharHUDInfo for collectable Processor");
                var collectiblesWithSettings = settings.GetCollectiblesWithSettings();

                _characterHUDManager.NewObjToBackpackAsync(collectiblesWithSettings);
            }

            base.Process(objSettings, interactState);
        }
    }
}
