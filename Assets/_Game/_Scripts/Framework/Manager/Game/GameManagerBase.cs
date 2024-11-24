using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Player.Interfaces;
using R3;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.Game
{
    public abstract class GameManagerBase : MonoBehaviour, IGameManager
    {
        public ReactiveProperty<int> PlayerInitialHealth { get; } = new();
        public ReadOnlyReactiveProperty<int> PlayerHealth => PlayerModel.Health;
        public ReactiveProperty<bool> IsGameStarted { get; } = new();

        public abstract void GameOver();
        public abstract void StopTheGame();
        public abstract void StartNewGame();
        public abstract void Pause();
        public abstract void UnPause();

        protected bool IsGamePaused;

        protected IPlayerModel PlayerModel;
        protected ISettingsManager SettingsManager;

        private IObjectResolver _resolver;


        [Inject]
        private void Construct(IObjectResolver resolver) => _resolver = resolver;

        protected void Awake()
        {
            PlayerModel = ResolverHelp.ResolveAndCheck<IPlayerModel>(_resolver);

            PlayerInitialHealth.Value = PlayerModel.CharSettings.health;
        }
    }
}
