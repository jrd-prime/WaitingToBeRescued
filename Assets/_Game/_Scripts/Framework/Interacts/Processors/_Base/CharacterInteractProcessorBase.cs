using System;
using _Game._Scripts.Framework.Data.SO.Obj.InWorld;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Stuff._Base;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.Processors._Base
{
    public interface IInteractProcessor
    {
        public IInteractProcessor SetNext(IInteractProcessor processor);
        public void Process(InWorldObjectSO objSO, EInteractState interactState);
    }

    public abstract class CharacterInteractProcessorBase : IInteractProcessor
    {
        protected abstract string Description { get; }
        protected IStuffDataManager StuffDataManager { get; private set; }

        private IInteractProcessor _next;

        [Inject]
        private void Construct(IStuffDataManager stuffDataManager)
        {
            StuffDataManager = stuffDataManager;
        }

        public IInteractProcessor SetNext(IInteractProcessor processor) =>
            _next = processor ?? throw new ArgumentNullException(nameof(processor));

        public virtual void Process(InWorldObjectSO objSO, EInteractState interactState)
        {
            if (StuffDataManager == null) throw new NullReferenceException("StuffDataManager is null");

            // Debug.LogWarning("<color=blue>" + Description + "</color>");

            _next?.Process(objSO, interactState);
        }
    }
}
