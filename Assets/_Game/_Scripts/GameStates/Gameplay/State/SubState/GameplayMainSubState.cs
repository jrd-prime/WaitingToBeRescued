using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.SubState;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.GameStates.Gameplay.State.SubState
{
    public class GameplayMainSubState : SubStateBase
    {
        public GameplayMainSubState(IUIManager uiManager, EGameState baseState, Enum defaultSubState) : base(uiManager,
            baseState, defaultSubState)
        {
        }

        public override void Enter()
        {
            ShowView();
        }

        public override void Exit()
        {
            // Hide only when we change BASE state
            // HideView();
        }
    }
}
