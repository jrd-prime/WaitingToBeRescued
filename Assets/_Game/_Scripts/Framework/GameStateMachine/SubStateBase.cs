using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.Framework.GameStateMachine
{
    public abstract class SubStateBase : ISubState
    {
        protected IUIManager UIManager;

        protected readonly EGameState BaseState;
        protected Enum CurrentSubState { get; set; }
        protected Enum DefaultSubState { get; }

        protected SubStateBase(IUIManager uiManager, EGameState baseState, Enum defaultSubState)
        {
            UIManager = uiManager ?? throw new ArgumentNullException(nameof(uiManager));
            DefaultSubState = defaultSubState ?? throw new ArgumentNullException(nameof(defaultSubState));
            CurrentSubState = DefaultSubState;
            BaseState = baseState;
        }

        public abstract void Enter();

        public abstract void Exit();
    }
}
