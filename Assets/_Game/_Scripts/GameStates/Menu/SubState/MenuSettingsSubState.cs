using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Manager.UI;
using UnityEngine;

namespace _Game._Scripts.GameStates.Menu.SubState
{
    public sealed class MenuSettingsSubState : SubStateBase
    {
        public MenuSettingsSubState(IUIManager uiManager, EGameState baseState, EMenuSubState defaultSubState) : base(
            uiManager, baseState, defaultSubState)
        {
        }

        public override void Enter()
        {
            Debug.LogWarning("Enter settings sub state " + DefaultSubState + " / " + this);
            UIManager.ShowView(BaseState, DefaultSubState, true);
        }

        public override void Exit()
        {
            Debug.LogWarning("Exit settings sub state " + DefaultSubState + " / " + this);
            UIManager.HideView(BaseState, DefaultSubState);
        }
    }
}
