using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Player.Data;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Interacts.WorldObjs._Base
{
    public interface IInteractProcessor
    {
        public IInteractProcessor SetNext(IInteractProcessor processor);
        public void Process(InGameObjectSO objSO, EInteractState interactState);
    }

    public abstract class CharacterInteractProcessorBase : IInteractProcessor
    {
        protected abstract string Description { get; }
        protected IPlayerDataManager PlayerDataManager { get; private set; }

        private IInteractProcessor _next;

        [Inject]
        private void Construct(IPlayerDataManager playerDataManager)
        {
            PlayerDataManager = playerDataManager;
        }

        public IInteractProcessor SetNext(IInteractProcessor processor) =>
            _next = processor ?? throw new ArgumentNullException(nameof(processor));

        public virtual void Process(InGameObjectSO objSO, EInteractState interactState)
        {
            if (PlayerDataManager == null) throw new NullReferenceException("PlayerDataManager is null");

            Debug.LogWarning("<color=green>^^^ " + Description + " ^^^</color>");

            _next?.Process(objSO, interactState);
        }
    }
}
