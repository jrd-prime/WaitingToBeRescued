using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Manager.UI;
using UnityEngine;

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
            Debug.LogWarning("Enter sub state " + DefaultSubState + " / " + this);
            UIManager.ShowView(BaseState, DefaultSubState, true);
        }

        public override void Exit()
        {
            Debug.LogWarning("Exit sub state " + DefaultSubState + " / " + this);
            UIManager.HideView(BaseState, DefaultSubState);
        }
    }
}
