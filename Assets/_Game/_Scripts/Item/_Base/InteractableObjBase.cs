using _Game._Scripts.Framework.Data.DTO.InteractableObj;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interact.Character;
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
        private CollectionProcessor _collectionProcessor;
        private ConditionCollectionProcessor _conditionCollectionProcessor;
        private ShowCharHUDInfoProcessor _hudInfoProcessor;
        private InteractionProcessor _interactionProcessor;
        private ConditionInteractionProcessor _conditionInteractionProcessor;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _showDebugProcessor = ResolverHelp.ResolveAndCheck<ShowDebugProcessor>(resolver);
            _collectionProcessor = ResolverHelp.ResolveAndCheck<CollectionProcessor>(resolver);
            _conditionCollectionProcessor = ResolverHelp.ResolveAndCheck<ConditionCollectionProcessor>(resolver);
            _interactionProcessor = ResolverHelp.ResolveAndCheck<InteractionProcessor>(resolver);
            _conditionInteractionProcessor = ResolverHelp.ResolveAndCheck<ConditionInteractionProcessor>(resolver);
            _hudInfoProcessor = ResolverHelp.ResolveAndCheck<ShowCharHUDInfoProcessor>(resolver);
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            _startChain = _showDebugProcessor;
            _startChain.SetNext(_collectionProcessor)
                .SetNext(_conditionCollectionProcessor)
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
