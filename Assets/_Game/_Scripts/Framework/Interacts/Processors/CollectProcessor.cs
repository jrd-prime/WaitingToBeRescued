using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;
using _Game._Scripts.Framework.Data.SO.Obj.InWorld;
using _Game._Scripts.Framework.Interacts.Processors._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Stuff;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.Processors
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

        public override void Process(InWorldObjectSO objSO, EInteractState interactState)
        {
            if (objSO is CollectableSO settings && interactState is EInteractState.EnoughForCollect)
            {
                Debug.LogWarning("Collect!");
                PickUpItems(settings);
            }

            base.Process(objSO, interactState);
        }

        private void PickUpItems(CollectableSO so)
        {
            var pickableItems = so.GetCollectiblesWithId();

            foreach (var resource in pickableItems) Debug.LogWarning($"Pick: {resource.Key} {resource.Value} ");

            _backpack.AddItems(pickableItems);
        }
    }
}
