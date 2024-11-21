﻿using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class WinState : GameStateBase, IGameState
    {
        public void Enter()
        {
            Debug.LogWarning("win state enter");

            UIManager.ShowView(GameStateType.Win);
            GameManager.StopTheGame();
        }

        public void Exit()
        {
            Debug.LogWarning("win state exit");
            UIManager.HideView(GameStateType.Win);
        }
    }
}
