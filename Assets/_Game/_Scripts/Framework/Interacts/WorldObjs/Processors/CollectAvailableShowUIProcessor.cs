using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using _Game._Scripts.Item._Base;
using _Game._Scripts.Player.HUD;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    /// <summary>
    /// If conditions are met, show collect UI
    /// </summary>
    [UsedImplicitly]
    public class CollectAvailableShowUIProcessor : CharacterInteractProcessorBase
    {
        private CharacterHUDManager _characterHUDManager;

        [Inject]
        private void Construct(CharacterHUDManager characterHUDManager)
        {
            _characterHUDManager = characterHUDManager;
        }

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (_characterHUDManager == null) throw new NullReferenceException("CharHud is null");

            Debug.LogWarning("interactState: " + interactState);

            if (objSO is CollectableSO settings && interactState == EInteractState.EnoughForCollect)
            {
                Debug.LogWarning("ENOUGH FOR COLLECT UI INFO");
                Debug.LogWarning("ShowCharHUDInfo for collectable Processor");
                var collectiblesWithSettings = settings.GetCollectiblesWithSettings();

                _characterHUDManager.NewObjToBackpackAsync(collectiblesWithSettings);
            }

            base.Process(objSO, interactState);
        }
    }
}
