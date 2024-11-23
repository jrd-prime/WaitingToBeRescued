using System;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.Framework.GameStateMachine.State.Menu.SubState
{
    public abstract class SubStateBase : ISubState
    {
        protected IUIManager UIManager;

        protected Enum CurrentSubState { get; set; }

        public SubStateBase(IUIManager uiManager)
        {
            UIManager = uiManager;
        }

        public abstract void Enter();

        public abstract void Exit();
    }
}
