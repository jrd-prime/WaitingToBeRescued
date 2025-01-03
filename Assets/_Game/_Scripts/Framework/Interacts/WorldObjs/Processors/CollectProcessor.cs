using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Settings;
using _Game._Scripts.Inventory;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Processors
{
    [UsedImplicitly]
    public class CollectProcessor : CharacterInteractProcessorBase
    {
        protected override string Description => "Collect Processor";

        private IBackpack _backpack;

        [Inject]
        private void Construct(IBackpack backpack)
        {
            _backpack = backpack;
        }

        public override void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (objSO is CollectableSO settings &&
                interactState is EInteractState.Start or EInteractState.EnoughForCollect)
            {
                Debug.LogWarning("Collect Processor");
                interactState = EInteractState.EnoughForCollect;
                PickItems(settings);
            }

            base.Process(objSO, interactState);
        }

        private void PickItems(CollectableSO so)
        {
            var pickableItems = so.GetCollectiblesWithId();

            foreach (var resource in pickableItems) Debug.LogWarning($"Pick: {resource.Key} {resource.Value} ");

            _backpack.AddItems(pickableItems);
        }
    }
}
