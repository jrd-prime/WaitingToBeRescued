using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsBehaviour;
using _Game._Scripts.Item._Base;

namespace _Game._Scripts.Framework.Interacts.WorldObjs._Base
{
    public interface IInteractProcessor
    {
        public IInteractProcessor SetNext(IInteractProcessor processor);
        public void Process(InGameObjectSettings objSettings, EInteractState interactState);
    }

    public abstract class CharacterInteractProcessorBase : IInteractProcessor
    {
        private IInteractProcessor _next;

        public IInteractProcessor SetNext(IInteractProcessor processor) =>
            _next = processor ?? throw new ArgumentNullException(nameof(processor));

        public virtual void Process(InGameObjectSettings objSettings, EInteractState interactState) =>
            _next?.Process(objSettings, interactState);
    }
}
