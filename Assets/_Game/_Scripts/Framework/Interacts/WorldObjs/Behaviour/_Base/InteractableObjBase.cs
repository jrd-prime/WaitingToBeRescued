using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Interacts.Processors;
using _Game._Scripts.Framework.Interacts.Processors._Base;
using _Game._Scripts.Framework.Interacts.Processors._Base;
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
        private CheckInteractConditionsProcessor _checkInteractConditions;
        private CollectUIProcessor _collectUI;

        private UseProcessor _use;
        private UseUIProcessor _useUI;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _showDebug = ResolverHelp.ResolveAndCheck<ShowDebugProcessor>(resolver);

            _collect = ResolverHelp.ResolveAndCheck<CollectProcessor>(resolver);
            _checkInteractConditions = ResolverHelp.ResolveAndCheck<CheckInteractConditionsProcessor>(resolver);
            _collectUI = ResolverHelp.ResolveAndCheck<CollectUIProcessor>(resolver);

            _use = ResolverHelp.ResolveAndCheck<UseProcessor>(resolver);
            _useUI = ResolverHelp.ResolveAndCheck<UseUIProcessor>(resolver);
        }

        private void Start()
        {
            _startChain = _showDebug;
            _startChain
                .SetNext(_checkInteractConditions)
                .SetNext(_use)
                .SetNext(_useUI)
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
}
