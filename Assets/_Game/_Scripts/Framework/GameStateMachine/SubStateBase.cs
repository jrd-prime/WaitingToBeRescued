using System;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.Framework.GameStateMachine
{
    public abstract class SubStateBase : ISubState
    {
        protected IUIManager UIManager;

        protected Enum CurrentSubState { get; set; }
        protected Enum DefaultSubState { get; }

        protected SubStateBase(IUIManager uiManager, Enum defaultSubState)
        {
            UIManager = uiManager ?? throw new ArgumentNullException(nameof(uiManager));
            DefaultSubState = defaultSubState ?? throw new ArgumentNullException(nameof(defaultSubState));
            CurrentSubState = DefaultSubState;
        }

        public abstract void Enter();

        public abstract void Exit();
    }
}
