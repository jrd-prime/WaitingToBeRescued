using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj;
using _Game._Scripts.Inventory;
using _Game._Scripts.Item._Base;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class CollectProcessor : CharacterInteractProcessorBase
    {
        private IBackpack _backpack;

        [Inject]
        private void Construct(IBackpack backpack)
        {
            _backpack = backpack;
        }

        public override void Process(InGameObjectSettings objSettings, EInteractState interactState)
        {
            if (objSettings is CollectableObjSettings settings &&
                interactState is EInteractState.Start or EInteractState.EnoughForCollect)
            {
                Debug.LogWarning("Collect Processor");
                PickItems(settings);
            }

            base.Process(objSettings, interactState);
        }

        private void PickItems(CollectableObjSettings settings)
        {
            var pickableItems = settings.GetCollectiblesWithId();

            foreach (var resource in pickableItems) Debug.LogWarning($"Pick: {resource.Key} {resource.Value} ");

            _backpack.AddItems(pickableItems);
        }
    }
}
