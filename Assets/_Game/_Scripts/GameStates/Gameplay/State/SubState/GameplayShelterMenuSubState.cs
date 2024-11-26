using System;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.SubState;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.GameStates.Gameplay.State.SubState
{
    public class GameplayShelterMenuSubState : SubStateBase
    {
        public GameplayShelterMenuSubState(IUIManager uiManager, EGameState baseState, Enum defaultSubState) : base(
            uiManager,
            baseState, defaultSubState)
        {
        }

        public override void Enter()
        {
            ShowView(EShowLogic.OverSubView);
        }

        public override void Exit()
        {
            HideView();
        }
    }
}
