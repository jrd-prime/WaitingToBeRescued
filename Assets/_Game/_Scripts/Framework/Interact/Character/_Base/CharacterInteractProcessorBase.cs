using System;
using _Game._Scripts.Framework.Data.DTO.InteractableObj;

namespace _Game._Scripts.Framework.Interact.Character._Base
{
    public interface IInteractProcessor
    {
        public IInteractProcessor SetNext(IInteractProcessor processor);
        public void Process(IInteractObjectDto objDto);
    }

    public abstract class CharacterInteractProcessorBase : IInteractProcessor
    {
        private IInteractProcessor _next;

        public IInteractProcessor SetNext(IInteractProcessor processor) =>
            _next = processor ?? throw new ArgumentNullException(nameof(processor));

        public virtual void Process(IInteractObjectDto objDto) => _next?.Process(objDto);
    }
}
