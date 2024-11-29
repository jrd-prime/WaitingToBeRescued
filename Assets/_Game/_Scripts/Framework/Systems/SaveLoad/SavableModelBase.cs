using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Manager.Settings;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Systems.SaveLoad
{
    public abstract class SavableModelBase<TSettings, TSavableDto> : IInitializable, IDisposable
        where TSettings : SettingsSO
    {
        public ReactiveProperty<TSavableDto> ModelData { get; } = new();
        public ReactiveProperty<bool> IsModelLoaded { get; } = new(false);
        public TSettings ModelSettings { get; private set; }
        public GameplaySettings GameplaySettings { get; private set; }

        private ISettingsManager _settingsManager;
        private ISaveSystem _saveSystem;
        private const float SaveDelay = 10f;
        private DateTime _lastSaveTime;

        [Inject]
        private void Construct(ISaveSystem iSaveSystem, ISettingsManager settingsManager)
        {
            _saveSystem = iSaveSystem;
            _settingsManager = settingsManager;
        }

        public void Initialize()
        {
            _lastSaveTime = DateTime.UtcNow;

            ModelSettings = _settingsManager.GetConfig<TSettings>();
            GameplaySettings = _settingsManager.GetConfig<GameplaySettings>();

            var defaultModelData = GetDefaultModelData();
            _saveSystem.LoadDataAsync(SetLoadedModelData, defaultModelData).Forget();
        }

        public TSavableDto GetModelData() => ModelData.CurrentValue;

        public void SetModelData(TSavableDto data)
        {
            ModelData.Value = data;
            ModelData.ForceNotify();

            var currentTime = DateTime.UtcNow;
            var timeElapsed = (currentTime - _lastSaveTime).TotalSeconds;

            if (!(timeElapsed >= SaveDelay)) return;
            _lastSaveTime = currentTime;
            _saveSystem.SaveToFileAsync(ModelData.CurrentValue).Forget();
        }

        private void SetLoadedModelData(TSavableDto data)
        {
            SetModelData(data);
            IsModelLoaded.Value = true;
        }

        private void ShowDebug() => Debug.LogWarning($"{typeof(TSavableDto).Name}: {GetDebugLine()}");

        protected abstract TSavableDto GetDefaultModelData();
        protected abstract string GetDebugLine();

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
    }
}
