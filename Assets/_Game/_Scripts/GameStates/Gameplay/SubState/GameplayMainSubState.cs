using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.GameStates.Gameplay.SubState
{
    public class GameplayMainSubState : SubStateBase
    {
        public GameplayMainSubState(IUIManager uiManager, EGameState baseState, Enum defaultSubState) : base(uiManager,
            baseState, defaultSubState)
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
