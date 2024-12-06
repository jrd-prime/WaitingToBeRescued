using System;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Interactable._Base
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
            if (!IsRightLayer(other)) return;

            Debug.LogWarning($"Entered trigger zone. {name}");
            _model.InteractOnEnter();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!IsRightLayer(other)) return;
            _model.InteractOnStay();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsRightLayer(other)) return;
            
            Debug.LogWarning($"Exit trigger zone. {name}");
            _model.InteractOnExit();
        }

        private bool IsRightLayer(Collider other) => ((1 << other.gameObject.layer) & layerForTrigger) != 0;
    }
}
