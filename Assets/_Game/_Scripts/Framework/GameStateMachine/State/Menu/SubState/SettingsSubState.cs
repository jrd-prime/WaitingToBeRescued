using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.UI;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Menu.SubState
{
    public sealed class SettingsSubState : SubStateBase
    {
        public SettingsSubState(IUIManager uiManager, EMenuSubState defaultSubState) : base(uiManager, defaultSubState)
        {
        }

        public override void Enter()
        {
            Debug.LogWarning("Enter settings sub state " + DefaultSubState + " / " + this);
            UIManager.ShowView(EGameState.Menu, DefaultSubState, true);
        }

        public override void Exit()
        {
            Debug.LogWarning("Exit settings sub state " + DefaultSubState + " / " + this);
            UIManager.HideView(EGameState.Menu, DefaultSubState);
        }
    }
}
