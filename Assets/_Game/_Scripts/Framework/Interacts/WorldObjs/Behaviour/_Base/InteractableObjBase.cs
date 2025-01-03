using _Game._Scripts.Framework.Data.SO;
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

        private ShowDebugProcessor _showDebug;

        private CollectProcessor _collect;
        private CollectWithConditionProcessor _collectWithCondition;
        private CollectUIProcessor _collectUI;

        private UseProcessor _use;
        private UseWithConditionProcessor _useWithCondition;
        private UseUIProcessor _useUI;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _showDebug = ResolverHelp.ResolveAndCheck<ShowDebugProcessor>(resolver);

            _collect = ResolverHelp.ResolveAndCheck<CollectProcessor>(resolver);
            _collectWithCondition = ResolverHelp.ResolveAndCheck<CollectWithConditionProcessor>(resolver);
            _collectUI = ResolverHelp.ResolveAndCheck<CollectUIProcessor>(resolver);

            _use = ResolverHelp.ResolveAndCheck<UseProcessor>(resolver);
            _useWithCondition = ResolverHelp.ResolveAndCheck<UseWithConditionProcessor>(resolver);
            _useUI = ResolverHelp.ResolveAndCheck<UseUIProcessor>(resolver);
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            _startChain = _showDebug;
            _startChain
                .SetNext(_useWithCondition)
                .SetNext(_use)
                .SetNext(_useUI)
                .SetNext(_collectWithCondition)
                .SetNext(_collect)
                .SetNext(_collectUI);

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
        NotEnoughForUse,
        EnoughForUse
    }
}
