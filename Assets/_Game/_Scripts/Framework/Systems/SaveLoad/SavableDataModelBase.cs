using System;
using System.Threading.Tasks;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Manager.Settings;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Systems.SaveLoad
{
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
        protected TSavableDto CurrentModelData;

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

            ModelSettings = _settingsManager.GetConfig<TSettings>();
            GameplaySettings = _settingsManager.GetConfig<GameplaySettings>();
            GameTimerSettings = _settingsManager.GetConfig<GameTimerSettings>();

            _defaultModelData = GetDefaultModelData();
            _saveSystem.LoadDataAsync(SetLoadedModelData, _defaultModelData).Forget();
        }

        protected void OnModelDataUpdated(TSavableDto data)
        {
            Type dataType = data.GetType();

            if (dataType.IsClass)
            {
                // Debug.LogWarning("data is a class.");
                CurrentModelData = data;
                Notify();
            }
            else if (dataType.IsValueType)
            {
                // Debug.LogWarning("data is a struct.");
                CurrentModelData = data;
                ModelData.Value = data;
            }

            AutoSave();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void AutoSave()
        {
            var currentTime = DateTime.UtcNow;
            var timeElapsed = (currentTime - _lastSaveTime).TotalSeconds;

            if (!(timeElapsed >= SaveDelay)) return;
            _lastSaveTime = currentTime;
            _saveSystem.SaveToFileAsync(CurrentModelData).Forget();
        }

        protected void Notify() => ModelData.ForceNotify();

        private void SetLoadedModelData(TSavableDto data)
        {
            OnModelDataUpdated(data);
            IsModelLoaded.Value = true;
        }

        private void ShowDebug() => Debug.LogWarning($"{typeof(TSavableDto).Name}: {GetDebugLine()}");

        protected abstract TSavableDto GetDefaultModelData();
        protected abstract string GetDebugLine();

        public async void Dispose()
        {
            try
            {
                await _saveSystem.SaveToFileAsync(CurrentModelData);
                ModelData?.Dispose();
                IsModelLoaded?.Dispose();
                ShowDebug();
            }
            catch (Exception e)
            {
                Debug.LogWarning("Disposing failed. " + typeof(TSavableDto).Name + " / " + e.Message);
            }
        }
    }
}
