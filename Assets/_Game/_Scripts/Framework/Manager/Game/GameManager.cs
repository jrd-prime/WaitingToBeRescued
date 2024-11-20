using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Game
{
    public class GameManager : GameManagerBase
    {
        public override void GameOver()
        {
            IsGameStarted.Value = false;
        }

        public override void StopTheGame()
        {
            IsGameStarted.Value = false;
        }

        public override void StartNewGame()
        {
            if (IsGameStarted.CurrentValue) return;

            IsGameStarted.Value = true;
            PlayerModel.ResetPlayer();
        }

        public override void Pause()
        {
            IsGamePaused = true;
            Time.timeScale = 0;
        }

        public override void UnPause()
        {
            IsGamePaused = false;
            Time.timeScale = 1;
        }
    }
}
