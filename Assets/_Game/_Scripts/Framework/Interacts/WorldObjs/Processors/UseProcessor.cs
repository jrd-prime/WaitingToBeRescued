using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsBehaviour;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings;
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

        public override void Process(InGameObjectSettings objSettings, EInteractState interactState)
        {
            // if (objSettings is InteractableObjDto)
            // {
            //     Debug.LogWarning("Interact Processor");
            //     Debug.LogWarning("obj is Pickable!!");
            //     // PickItems((CollectableObjSettings)objDto.Settings);
            // }

            base.Process(objSettings, interactState);
        }

        private void PickItems(CollectableSettings settings)
        {
            // var pickableItems = settings.objReturns.GetAllItems();

            // foreach (var resource in pickableItems) Debug.LogWarning($"Pick: {resource.Key} {resource.Value} ");

            // _backpack.AddItems(pickableItems);
        }
    }
}
