using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Manager.UI;
using UnityEngine;

namespace _Game._Scripts.GameStates.Menu.SubState
{
    public class MenuMainSubState : SubStateBase
    {
        public MenuMainSubState(IUIManager uiManager, EGameState baseState, EMenuSubState defaultSubState) : base(
            uiManager, baseState, defaultSubState)
        {
        }

        public override void Enter()
        {
            UIManager.ShowView(BaseState, DefaultSubState, true);
        }

        public override void Exit()
        {
            UIManager.HideView(BaseState, DefaultSubState);
        }
    }
}
