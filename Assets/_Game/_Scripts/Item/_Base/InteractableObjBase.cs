using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interacts.WorldObjs._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Processors;
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
        private CollectProcessor _collectProcessor;
        private CollectWithConditionProcessor _collectWithConditionProcessor;
        private EnoughForCollectUIInfoProcessor _enoughForEnoughForCollectUIProcessor;
        private InteractProcessor _interactProcessor;
        private InteractWithConditionProcessor _interactWithConditionProcessor;
        private NotEnoughForCollectProcessor _notEnoughForCollectUIProcessor;
        private NotEnoughForInteractProcessor _notEnoughForInteractUIProcessor;
        private EnoughForInteractUIInfoProcessor _enoughForEnoughForInteractUIProcessor;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _showDebugProcessor = ResolverHelp.ResolveAndCheck<ShowDebugProcessor>(resolver);
            _collectProcessor = ResolverHelp.ResolveAndCheck<CollectProcessor>(resolver);
            _collectWithConditionProcessor = ResolverHelp.ResolveAndCheck<CollectWithConditionProcessor>(resolver);
            _interactProcessor = ResolverHelp.ResolveAndCheck<InteractProcessor>(resolver);
            _interactWithConditionProcessor = ResolverHelp.ResolveAndCheck<InteractWithConditionProcessor>(resolver);

            _notEnoughForCollectUIProcessor = ResolverHelp.ResolveAndCheck<NotEnoughForCollectProcessor>(resolver);
            _notEnoughForInteractUIProcessor = ResolverHelp.ResolveAndCheck<NotEnoughForInteractProcessor>(resolver);

            _enoughForEnoughForCollectUIProcessor = ResolverHelp.ResolveAndCheck<EnoughForCollectUIInfoProcessor>(resolver);
            _enoughForEnoughForInteractUIProcessor = ResolverHelp.ResolveAndCheck<EnoughForInteractUIInfoProcessor>(resolver);
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            _startChain = _showDebugProcessor;
            _startChain
                .SetNext(_interactWithConditionProcessor)
                .SetNext(_interactProcessor)
                .SetNext(_collectWithConditionProcessor)
                .SetNext(_collectProcessor)
                .SetNext(_notEnoughForCollectUIProcessor)
                .SetNext(_notEnoughForInteractUIProcessor)
                .SetNext(_enoughForEnoughForCollectUIProcessor)
                .SetNext(_enoughForEnoughForInteractUIProcessor);

            OnStartInitialization();
        }

        protected virtual void OnStartInitialization()
        {
        }

        protected void StartInteract(InGameObjectSettings obj) => _startChain?.Process(obj, EInteractState.Start);

        protected void FinishInteract(InGameObjectSettings obj) => _finishChain.Process(obj, EInteractState.Start);
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
