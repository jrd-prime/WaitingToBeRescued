using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interact.Character._Base;
using _Game._Scripts.Framework.Interact.Character.Processors;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Item._Base
{
    [RequireComponent(typeof(Collider))]
    public abstract class InteractableObjBase : MonoBehaviour
    {
        private IInteractProcessor _startChain;
        private IInteractProcessor _finishChain;

        private ShowDebugProcessor _showDebugProcessor;
        private PickUpProcessor _pickUpProcessor;
        private GatherProcessor _gatherProcessor;
        private ShowCharHUDInfoProcessor _hudInfoProcessor;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _showDebugProcessor = ResolverHelp.ResolveAndCheck<ShowDebugProcessor>(resolver);
            _pickUpProcessor = ResolverHelp.ResolveAndCheck<PickUpProcessor>(resolver);
            _gatherProcessor = ResolverHelp.ResolveAndCheck<GatherProcessor>(resolver);
            _hudInfoProcessor = ResolverHelp.ResolveAndCheck<ShowCharHUDInfoProcessor>(resolver);
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            _startChain = _showDebugProcessor;
            _startChain.SetNext(_pickUpProcessor)
                .SetNext(_gatherProcessor)
                .SetNext(_hudInfoProcessor);

            OnStartInitialization();
        }

        protected virtual void OnStartInitialization()
        {
        }

        protected void StartInteract(IInteractObjectDto obj) => _startChain?.Process(obj);

        protected void FinishInteract(IInteractObjectDto obj) => _finishChain.Process(obj);
    }
}
