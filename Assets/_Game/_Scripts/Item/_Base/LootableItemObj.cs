using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Item.Pickable;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace _Game._Scripts.Item._Base
{
    public abstract class LootableItemObj<TSystemHandler, TSettingsDto> : InteractableItemBase
        where TSystemHandler : IInteractableItemSystem
        where TSettingsDto : IItemDto
    {
        [SerializeField] protected LayerMask layerForTrigger;
        [SerializeField] protected TSettingsDto settingsDto;

        protected TSystemHandler InteractHandler { get; private set; }

        [Inject]
        private void Construct(TSystemHandler systemHandler) => InteractHandler = systemHandler;


        private void Start()
        {
            // if (returns == null) throw new NullReferenceException("ItemSettings is null.");
            if (InteractHandler == null) throw new NullReferenceException("InteractHandler is null.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger)) InteractHandler.OnEnter(settingsDto);
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

    [Serializable]
    public struct LootableItemSettingsDto : IItemDto
    {
        public List<CustomItemValue<LootableItemSettings>> loot;
        public List<LootableItemRequirements> requirements;
    }
}
