using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Systems.SaveLoad;
using _Game._Scripts.Player.Interfaces;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.Game
{
    public abstract class GameManagerBase : MonoBehaviour, IGameManager
    {
        public ReactiveProperty<int> PlayerInitialHealth { get; } = new();
        public ReadOnlyReactiveProperty<int> PlayerHealth => PlayerModel.Health;
        public ReactiveProperty<bool> IsGameRunning { get; } = new(false);
        public ReactiveProperty<GameTimeDto> GameTimeData { get; } = new();

        protected bool IsGamePaused;
        protected IPlayerModel PlayerModel;
        protected ISettingsManager SettingsManager;

        private GameTimeDto _gameTimeData;
        private GameTimer _gameTimer;
        private IObjectResolver _resolver;
        private readonly CompositeDisposable _disposables = new();
        private ISaveSystem _saveSystem;
        private GameTimerSettings _gameplaySettings;
        private GameTimeModel _gameTimeModel;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;

            _saveSystem = resolver.Resolve<ISaveSystem>();
            SettingsManager = _resolver.Resolve<ISettingsManager>();

            _gameTimeModel = _resolver.Resolve<GameTimeModel>();

            _gameplaySettings = SettingsManager.GetConfig<GameTimerSettings>();
        }

        public void Initialize()
        {
        }

        protected void Awake()
        {
            _gameTimer = new GameTimer(_gameplaySettings.gameDayInSeconds, this).AddTo(_disposables);
            _resolver.Inject(_gameTimer);

            PlayerModel = ResolverHelp.ResolveAndCheck<IPlayerModel>(_resolver);

            PlayerInitialHealth.Value = PlayerModel.CharSettings.health;

            IsGameRunning.DistinctUntilChanged()
                .Subscribe(isRunning =>
                {
                    Debug.LogWarning("IsGameRunning: " + isRunning);
                    _gameTimer.SetGameRunningState(isRunning);
                })
                .AddTo(_disposables);
        }

        public abstract void GameOver();
        public abstract void StopTheGame();
        public abstract void StartNewGame();
        public abstract void Pause();
        public abstract void UnPause();

        private void OnApplicationPause(bool pauseStatus)
        {
            _saveSystem.Save(_gameTimeData);
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}
