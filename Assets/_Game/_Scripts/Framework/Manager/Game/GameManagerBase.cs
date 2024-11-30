using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.Timer;
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
        public ReactiveProperty<bool> IsGameRunning { get; } = new(false);
        public ReactiveProperty<GameTimerData> GameTimeData { get; } = new();

        protected bool IsGamePaused;
        protected IPlayerModel PlayerModel;
        protected ISettingsManager SettingsManager;

        private GameTimer _gameTimer;
        private IObjectResolver _resolver;
        private readonly CompositeDisposable _disposables = new();
        private GameTimerSettings _gameplaySettings;
        private GameTimerModel _timerModel;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
            SettingsManager = _resolver.Resolve<ISettingsManager>();
            _timerModel = _resolver.Resolve<GameTimerModel>();
            _gameplaySettings = SettingsManager.GetConfig<GameTimerSettings>();
        }

        public void Initialize()
        {
            InitGameTimer();
        }

        protected void Awake()
        {
            PlayerModel = ResolverHelp.ResolveAndCheck<IPlayerModel>(_resolver);

            PlayerInitialHealth.Value = PlayerModel.CharSettings.health;

            IsGameRunning
                .DistinctUntilChanged()
                .Subscribe(_gameTimer.SetGameRunningState)
                .AddTo(_disposables);

            _timerModel.IsModelLoaded
                .DistinctUntilChanged().Where(x => x)
                .Take(1)
                .Subscribe(_ => _gameTimer.OnModelDataLoaded())
                .AddTo(_disposables);
        }

        private void InitGameTimer()
        {
            var timerOptions = new GameTimerOptions
            {
                DayCycleTime = _gameplaySettings.gameDayInSeconds,
                SaveInterval = 1f,
                UpdateInterval = .1f,
                TimerModel = _timerModel,
                MonoBehaviour = this
            };
            _gameTimer = new GameTimer(timerOptions).AddTo(_disposables);
            _resolver.Inject(_gameTimer);
        }

        public abstract void GameOver();
        public abstract void StopTheGame();
        public abstract void StartNewGame();
        public abstract void Pause();
        public abstract void UnPause();

        private void OnDestroy()
        {
            _gameTimer?.Dispose();
            _resolver?.Dispose();
            _disposables?.Dispose();
            _timerModel?.Dispose();
            PlayerInitialHealth?.Dispose();
            IsGameRunning?.Dispose();
            GameTimeData?.Dispose();
        }
    }
}
