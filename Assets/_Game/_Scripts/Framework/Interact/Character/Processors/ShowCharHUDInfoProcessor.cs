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
        private CharacterHUDController _characterHUDController;

        [Inject]
        private void Construct(CharacterHUDController characterHUDController)
        {
            Debug.LogWarning("con ShowCharHUDInfoProcessor");
            _characterHUDController = characterHUDController;
        }

        public override async void Process(IInteractObjectDto objDto)
        {
            if (objDto is PickableObjDto)
            {
                Debug.LogWarning("obj is Pickable!!");
                var a = (PickableObjSettings)objDto.Settings;


                foreach (var resource in a.objReturnsDto.resources)
                {
                    _characterHUDController.NewObjToBackpack(resource.itemSettings.icon, resource.itemSettings.name, resource.value);

                    await UniTask.Delay(500);
                }
            }


            base.Process(objDto);
        }
    }
}
