﻿using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Game
{
    public class GameManager : GameManagerBase
    {
        public override void GameOver()
        {
            IsGameRunning.Value = false;
        }

        public override void StopTheGame()
        {
            IsGameRunning.Value = false;
        }

        public override void StartNewGame()
        {
            if (IsGameRunning.CurrentValue) return;

            Debug.LogWarning("GAME STARTED");

            IsGameRunning.Value = true;
            IsGamePaused = false;
            PlayerModel.ResetPlayer();
        }

        public override void Pause()
        {
            Debug.LogWarning("Game Paused");
            IsGameRunning.Value = false;
            IsGamePaused = true;
            // Time.timeScale = 0;
        }

        public override void UnPause()
        {
            Debug.LogWarning("Game Unpaused");
            IsGameRunning.Value = true;
            IsGamePaused = false;
            // Time.timeScale = 1;
        }
    }
}
