using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Settings;
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
        private GameplaySettings _gameplaySettings;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;

            _saveSystem = resolver.Resolve<ISaveSystem>();
            SettingsManager = _resolver.Resolve<ISettingsManager>();
        }

        public void Initialize()
        {
            _gameplaySettings = SettingsManager.GetConfig<GameplaySettings>();

            // default game time data
            _gameTimeData = new GameTimeDto(_gameplaySettings.startDay, _gameplaySettings.gameDayInSeconds);

            // load if there is saved data, or save and set default data
            _saveSystem.LoadDataAsync(OnSavedDataLoaded, _gameTimeData).Forget();
        }

        private void OnSavedDataLoaded(GameTimeDto savedData)
        {
            Debug.LogWarning($"<b>On saved data loaded</b> From save: {savedData.Day} / {savedData.RemainingDayTime}");

            // set saved or loaded data
            _gameTimeData = savedData;
            GameTimeData.Value = _gameTimeData;
            // notify
            UpdateGameTimeDto();
            // Start game timer
            _gameTimer = new GameTimer(_gameplaySettings.gameDayInSeconds, this, ref _gameTimeData).AddTo(_disposables);
            _resolver.Inject(_gameTimer);
        }

        protected void Awake()
        {
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

        public void UpdateGameTimeDto()
        {
            GameTimeData.ForceNotify();
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
