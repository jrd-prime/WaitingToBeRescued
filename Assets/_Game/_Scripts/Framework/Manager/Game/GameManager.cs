using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Game
{
    public class GameManager : GameManagerBase
    {
        public void GameOver()
        {
            // EnemiesManager.StopSpawn();
            IsGameStarted.Value = false;
        }

        public void StopTheGame()
        {
            // EnemiesManager.StopSpawn();
            IsGameStarted.Value = false;
        }

        public void StartNewGame()
        {
            if (IsGameStarted.CurrentValue) return;

            IsGameStarted.Value = true;
            PlayerModel.ResetPlayer();
            // ExperienceManager.ResetExperience();

            // EnemiesManager.StartSpawnEnemiesAsync(KillsToWin, MinEnemiesOnMap, MaxEnemiesOnMap, SpawnDelay);
        }

        public void Pause()
        {
            IsGamePaused = true;
            Time.timeScale = 0;
        }

        public void UnPause()
        {
            IsGamePaused = false;
            Time.timeScale = 1;
        }
    }
}
