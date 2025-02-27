﻿using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JStateMachine.SubState;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.Framework.JStateMachine.State.Menu.State.SubState
{
    public class MenuMainSubState : SubStateBase
    {
        public MenuMainSubState(IUIManager uiManager, EGameState baseState, EMenuSubState defaultSubState) : base(
            uiManager, baseState, defaultSubState)
        {
        }

        public override void Enter()
        {
            ShowView();
        }

        public override void Exit()
        {
            // HideView();
        }
    }
}
