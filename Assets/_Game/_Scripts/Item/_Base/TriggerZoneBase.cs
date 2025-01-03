using System;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Shelter;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Item._Base
{
    public abstract class TriggerZoneBase<TInteractableModel> : MonoBehaviour
        where TInteractableModel : IInteractableModel
    {
        [SerializeField] protected LayerMask layerForTrigger;

        private TInteractableModel _model;

        [Inject]
        private void Construct(TInteractableModel interactableModel)
        {
            _model = interactableModel;
        }

        private void Start()
        {
            if (_model == null) throw new NullReferenceException("InteractableModel is null. Add me to auto inject.");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.IsRightLayer(layerForTrigger)) return;

            Debug.LogWarning($"Entered trigger zone. {name}");
            _model.InteractOnEnter();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.IsRightLayer(layerForTrigger)) return;
            _model.InteractOnStay();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.IsRightLayer(layerForTrigger)) return;

            Debug.LogWarning($"Exit trigger zone. {name}");
            _model.InteractOnExit();
        }
    }
}
