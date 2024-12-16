using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Item.Pickable;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Item._Base
{
    public abstract class NonLootableObjObj<TSystemHandler, TObjSettings> : InteractableObjBase
        where TSystemHandler : ILootableObjSystem<TObjSettings>
        where TObjSettings : InGameObjectSettings
    {
        [SerializeField] protected LayerMask layerForTrigger;
        [SerializeField] protected TObjSettings returns;
        protected TSystemHandler InteractHandler { get; private set; }

        [Inject]
        private void Construct(TSystemHandler systemHandler) => InteractHandler = systemHandler;


        private void Start()
        {
            // if (item == null) throw new NullReferenceException("ItemSettings is null.");
            if (InteractHandler == null) throw new NullReferenceException("InteractHandler is null.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger))
            {
                InteractHandler.SetObjSettings(returns);
                InteractHandler.OnEnter();
            }
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

    // [Serializable]
    // public struct NonLootableItemSettingsDto : IItemDto
    // {
    //     public List<CustomItemValue<LootableItemSettings>> returns;
    // }
}
