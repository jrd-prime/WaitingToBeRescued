using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using _Game._Scripts.Inventory;
using _Game._Scripts.Item._Base;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class UseProcessor : CharacterInteractProcessorBase
    {
        private IBackpack _backpack;

        [Inject]
        private void Construct(IBackpack backpack)
        {
            _backpack = backpack;
        }

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            // if (objSO is InteractableObjDto)
            // {
            //     Debug.LogWarning("Interact Processor");
            //     Debug.LogWarning("obj is Pickable!!");
            //     // PickItems((CollectableObjSettings)objDto.Settings);
            // }

            base.Process(objSO, interactState);
        }

        private void PickItems(CollectableSO so)
        {
            // var pickableItems = settings.objReturns.GetAllItems();

            // foreach (var resource in pickableItems) Debug.LogWarning($"Pick: {resource.Key} {resource.Value} ");

            // _backpack.AddItems(pickableItems);
        }
    }
}
