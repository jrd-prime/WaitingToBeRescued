using System;
using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interact.Character._Base;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interact.Character.Processors
{
    [UsedImplicitly]
    public class ShowCharHUDInfoProcessor : CharacterInteractProcessorBase
    {
        private CharacterHUDManager _characterHUDManager;

        [Inject]
        private void Construct(CharacterHUDManager characterHUDManager)
        {
            _characterHUDManager = characterHUDManager;
        }

        public override async void Process(IInteractObjectDto objDto)
        {
            if (_characterHUDManager == null) throw new NullReferenceException("CharHud is null");

            if (objDto is PickableObjDto)
            {
                Debug.LogWarning("obj is Pickable!!");
                var a = (PickableObjSettings)objDto.Settings;

                foreach (var resource in a.objReturnsDto.resources)
                {
                    _characterHUDManager.NewObjToBackpack(resource.itemSettings.icon, resource.itemSettings.name,
                        resource.value);

                    await UniTask.Delay(500);
                }
            }

            base.Process(objDto);
        }
    }
}
