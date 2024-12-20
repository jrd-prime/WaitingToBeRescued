using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj;
using _Game._Scripts.Player.HUD;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class CollectHUDInfoProcessor : CharacterInteractProcessorBase
    {
        private CharacterHUDManager _characterHUDManager;

        [Inject]
        private void Construct(CharacterHUDManager characterHUDManager)
        {
            _characterHUDManager = characterHUDManager;
        }

        public override async void Process(InGameObjectSettings settings)
        {
            if (_characterHUDManager == null) throw new NullReferenceException("CharHud is null");

            if (settings is CollectableObjSettings or CollectableObjWithRequirementsSettings)
            {
                Debug.LogWarning("ShowCharHUDInfo for collectable Processor");


                var a = (CollectableObjSettings)settings;

                foreach (var resource in a.collectibles.resources)
                {
                    _characterHUDManager.NewObjToBackpack(resource.itemSettings.icon, resource.itemSettings.name,
                        resource.value);

                    await UniTask.Delay(500);
                }
            }

            base.Process(settings);
        }
    }
}
