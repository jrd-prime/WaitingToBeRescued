using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.DTO.InteractableObj;
using _Game._Scripts.Inventory;
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

        public override void Process(InGameObjectSettings settings)
        {
            if (settings is CollectableObjSettings)
            {
                Debug.LogWarning("Collect Processor");
                Debug.LogWarning("obj is Pickable!!");
                PickItems((CollectableObjSettings)settings);
            }

            base.Process(settings);
        }

        private void PickItems(CollectableObjSettings settings)
        {
            var pickableItems = settings.collectibles.GetAllItems();

            foreach (var resource in pickableItems) Debug.LogWarning($"Pick: {resource.Key} {resource.Value} ");

            _backpack.AddItems(pickableItems);
        }
    }
}
