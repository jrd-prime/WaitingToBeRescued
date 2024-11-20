using R3;

namespace _Game._Scripts.Framework.Manager.Game
{
    public interface IGameManager
    {
        public ReactiveProperty<int> PlayerInitialHealth { get; }
        public ReadOnlyReactiveProperty<int> PlayerHealth { get; }
        public ReactiveProperty<bool> IsGameStarted { get; }

        public void GameOver();

        public void StopTheGame();

        public void StartNewGame();

        public void Pause();

        public void UnPause();
    }
}
