using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers.Extensions;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Item._Base
{
    public abstract class LootableObj<TSystemHandler, TObjSettings> : InteractableObjBase
        where TSystemHandler : ILootableObjSystem<TObjSettings>
        where TObjSettings : InGameObjectSettings
    {
        [SerializeField] protected LayerMask layerForTrigger;
        [SerializeField] protected TObjSettings objSettings;

        private TSystemHandler _interactHandler;

        [Inject]
        private void Construct(TSystemHandler systemHandler) => _interactHandler = systemHandler;

        private void Start()
        {
            if (objSettings == null) throw new NullReferenceException($"ObjSettings is null. {name}");
            if (_interactHandler == null) throw new NullReferenceException($"InteractHandler is null. {name}");

            OnStartInitialization();
        }

        protected virtual void OnStartInitialization()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.IsRightLayer(layerForTrigger)) return;
            _interactHandler.SetObjSettings(objSettings);
            _interactHandler.OnEnter();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger)) _interactHandler.OnStay();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.IsRightLayer(layerForTrigger)) _interactHandler.OnExit();
        }
    }
}
