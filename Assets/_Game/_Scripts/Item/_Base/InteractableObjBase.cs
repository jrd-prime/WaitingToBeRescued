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
        private IInteractProcessor _chain;

        private ShowDebugProcessor _showDebugProcessor;
        private PickUpProcessor _pickUpProcessor;
        private GatherProcessor _gatherProcessor;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _showDebugProcessor = ResolverHelp.ResolveAndCheck<ShowDebugProcessor>(resolver);
            _pickUpProcessor = ResolverHelp.ResolveAndCheck<PickUpProcessor>(resolver);
            _gatherProcessor = ResolverHelp.ResolveAndCheck<GatherProcessor>(resolver);
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            _chain = _showDebugProcessor;
            _chain.SetNext(_pickUpProcessor)
                .SetNext(_gatherProcessor);

            OnStartInitialization();
        }

        protected virtual void OnStartInitialization()
        {
        }

        protected void Inter(IInteractObjectDto obj) => _chain.Process(obj);
    }
}
