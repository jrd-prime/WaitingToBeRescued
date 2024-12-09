using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Helpers.Extensions;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Item
{
    public abstract class InteractableItem<TSystemHandler> : InteractableItemBase
        where TSystemHandler : IInteractableItemSystem
    {
        [SerializeField] protected LayerMask layerForTrigger;
        [RequiredField, SerializeField] protected GameItemSettings item;
        protected TSystemHandler InteractHandler { get; private set; }

        [Inject]
        private void Construct(TSystemHandler systemHandler) => InteractHandler = systemHandler;

        private void Start()
        {
            if (item == null) throw new NullReferenceException("ItemSettings is null.");
            if (InteractHandler == null) throw new NullReferenceException("InteractHandler is null.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger)) InteractHandler.OnEnter(item);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger)) InteractHandler.OnStay();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger)) InteractHandler.OnExit();
        }
    }

    public interface IInteractableItemSystem
    {
        public void OnEnter(GameItemSettings itemSettings);
        public void OnStay();
        public void OnExit();
    }
}
