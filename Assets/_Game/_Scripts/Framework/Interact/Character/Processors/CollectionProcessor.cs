using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interact.Character._Base;
using _Game._Scripts.Inventory;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interact.Character.Processors
{
    [UsedImplicitly]
    public class CollectionProcessor : CharacterInteractProcessorBase
    {
        private IBackpack _backpack;

        [Inject]
        private void Construct(IBackpack backpack)
        {
            _backpack = backpack;
        }

        public override void Process(IInteractObjectDto objDto)
        {
            if (objDto is CollectableObjDto)
            {
                Debug.LogWarning("obj is Pickable!!");
                // PickItems((CollectableObjSettings)objDto.Settings);
            }

            base.Process(objDto);
        }

        private void PickItems(CollectableObjSettings settings)
        {
            var pickableItems = settings.objReturnsDto.GetAllItems();

            foreach (var resource in pickableItems) Debug.LogWarning($"Pick: {resource.Key} {resource.Value} ");

            _backpack.AddItems(pickableItems);
        }
    }
}
