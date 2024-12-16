using System;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Game;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.Manager.Settings;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Systems.SaveLoad
{
    // TODO : refact, optimize & etc
    public abstract class SavableDataModelBase<TSettings, TSavableDto> : IInitializable, IDisposable
        where TSettings : SettingsSO
    {
        public ReactiveProperty<TSavableDto> ModelData { get; } = new();
        public ReactiveProperty<bool> IsModelLoaded { get; } = new(false);
        protected TSettings ModelSettings { get; private set; }
        protected GameplaySettings GameplaySettings { get; private set; }
        protected GameTimerSettings GameTimerSettings { get; private set; }

        private ISettingsManager _settingsManager;
        private ISaveSystem _saveSystem;
        private const float SaveDelay = 10f;
        private DateTime _lastSaveTime;
        private TSavableDto _defaultModelData;

        protected TSavableDto CachedModelData;
        private Type _modelDataType;

        [Inject]
        private void Construct(ISaveSystem iSaveSystem, ISettingsManager settingsManager)
        {
            _saveSystem = iSaveSystem;
            _settingsManager = settingsManager;
        }

        public void Initialize()
        {
            if (_saveSystem == null) throw new NullReferenceException("SaveSystem is null");
            if (_settingsManager == null) throw new NullReferenceException("SettingsManager is null");

            _lastSaveTime = DateTime.UtcNow;
            _modelDataType = typeof(TSavableDto);

            ModelSettings = _settingsManager.GetConfig<TSettings>();
            GameplaySettings = _settingsManager.GetConfig<GameplaySettings>();
            GameTimerSettings = _settingsManager.GetConfig<GameTimerSettings>();

            InitModel();
            _defaultModelData = GetDefaultModelData();
            _saveSystem.LoadDataAsync(OnModelDataLoaded, _defaultModelData).Forget();
        }


        protected void OnModelDataUpdated()
        {
            ModelData.Value = CachedModelData;

            ModelData.NotifyIfDataIsClass();
            // notify if it is a class

            AutoSave();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void AutoSave()
        {
            var currentTime = DateTime.UtcNow;
            var timeElapsed = (currentTime - _lastSaveTime).TotalSeconds;

            if (!(timeElapsed >= SaveDelay)) return;
            _lastSaveTime = currentTime;
            _saveSystem.SaveToFileAsync(CachedModelData).Forget();
        }

        private void Notify() => ModelData.ForceNotify();

        private void OnModelDataLoaded(TSavableDto data)
        {
            CachedModelData = data;
            Debug.LogWarning($"Loaded {GetDebugLine()}");
            OnModelDataUpdated();
            IsModelLoaded.Value = true;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void ShowDebug() => Debug.LogWarning($"{typeof(TSavableDto).Name}: {GetDebugLine()}");


        // ReSharper disable Unity.PerformanceAnalysis
        public async void Dispose()
        {
            try
            {
                await _saveSystem.SaveToFileAsync(ModelData.CurrentValue);
                ModelData?.Dispose();
                IsModelLoaded?.Dispose();
                ShowDebug();
            }
            catch (Exception e)
            {
                Debug.LogWarning("Disposing failed. " + typeof(TSavableDto).Name + " / " + e.Message);
            }
        }

        protected abstract void InitModel();
        protected abstract TSavableDto GetDefaultModelData();
        protected abstract string GetDebugLine();
    }
}
