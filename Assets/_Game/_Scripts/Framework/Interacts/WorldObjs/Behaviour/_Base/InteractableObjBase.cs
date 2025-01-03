using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Processors;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base
{
    [RequireComponent(typeof(Collider))]
    public abstract class InteractableObjBase : MonoBehaviour
    {
        private IInteractProcessor _startChain;
        private IInteractProcessor _finishChain;

        private ShowDebugProcessor _showDebugProcessor;
        private CollectProcessor _collectProcessor;
        private CollectWithConditionProcessor _collectWithConditionProcessor;
        private CollectAvailableShowUIProcessor _collectAvailableShowUIProcessor;
        private UseProcessor _useProcessor;
        private UseWithConditionProcessor _useWithConditionProcessor;
        private CollectUnavailableShowUIProcessor _collectUnavailableShowUIUIProcessor;
        private InteractUnavaiableShowUIProcessor _interactUnavaiableShowUIUIProcessor;
        private InteractAvailableShowUIProcessor _interactAvailableShowUIProcessor;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _showDebugProcessor = ResolverHelp.ResolveAndCheck<ShowDebugProcessor>(resolver);
            _collectProcessor = ResolverHelp.ResolveAndCheck<CollectProcessor>(resolver);
            _collectWithConditionProcessor = ResolverHelp.ResolveAndCheck<CollectWithConditionProcessor>(resolver);
            _useProcessor = ResolverHelp.ResolveAndCheck<UseProcessor>(resolver);
            _useWithConditionProcessor = ResolverHelp.ResolveAndCheck<UseWithConditionProcessor>(resolver);

            _collectUnavailableShowUIUIProcessor = ResolverHelp.ResolveAndCheck<CollectUnavailableShowUIProcessor>(resolver);
            _interactUnavaiableShowUIUIProcessor = ResolverHelp.ResolveAndCheck<InteractUnavaiableShowUIProcessor>(resolver);

            _collectAvailableShowUIProcessor = ResolverHelp.ResolveAndCheck<CollectAvailableShowUIProcessor>(resolver);
            _interactAvailableShowUIProcessor = ResolverHelp.ResolveAndCheck<InteractAvailableShowUIProcessor>(resolver);
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            _startChain = _showDebugProcessor;
            _startChain
                .SetNext(_useWithConditionProcessor)
                .SetNext(_useProcessor)
                .SetNext(_collectWithConditionProcessor)
                .SetNext(_collectProcessor)
                .SetNext(_collectUnavailableShowUIUIProcessor)
                .SetNext(_interactUnavaiableShowUIUIProcessor)
                .SetNext(_collectAvailableShowUIProcessor)
                .SetNext(_interactAvailableShowUIProcessor);

            OnStartInitialization();
        }

        protected virtual void OnStartInitialization()
        {
        }

        protected void StartInteract(InGameObjectSO obj) => _startChain?.Process(obj, EInteractState.Start);

        protected void FinishInteract(InGameObjectSO obj) => _finishChain.Process(obj, EInteractState.Start);
    }

    public enum EInteractState
    {
        Start = 0,
        EnoughForCollect,
        NotEnoughForCollect,
        NotEnoughForInteract,
        EnoughForInteract
    }
}
