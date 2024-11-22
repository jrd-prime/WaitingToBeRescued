﻿using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UIOLD;
using _Game._Scripts.UIOLD.Menus.Pause;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Pause
{
    public sealed class PauseState : GameStateBase<IPauseUIModel>
    {
        protected override void OnMainStateEnter()
        {
            UIManager.ShowView(GameStateType.Pause);
            GameManager.Pause();
        }

        protected override void OnMainStateExit()
        {
            UIManager.HideView(GameStateType.Pause);
            GameManager.UnPause();
        }

        protected override void SubscribeToModel()
        {
            
        }

        protected override void InitializeSubStates()
        {
            Debug.LogWarning("implement me");
        }
    }
}
