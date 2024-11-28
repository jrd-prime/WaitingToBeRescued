using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Framework.Manager.Shelter;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Systems.SaveLoad
{
    public abstract class SavableModelBase<TSettings, TSavableDto> : IInitializable where TSettings : SettingsSO
    {
        public ReactiveProperty<TSavableDto> ModelData { get; } = new();

        public TSettings ModelSettings { get; private set; }
        public GameplaySettings GameplaySettings { get; private set; }

        private ISettingsManager _settingsManager;

        private ISaveSystem _iSaveSystem;


        [Inject]
        private void Construct(ISaveSystem iSaveSystem, ISettingsManager settingsManager)
        {
            _iSaveSystem = iSaveSystem;
            _settingsManager = settingsManager;
        }

        public void Initialize()
        {
            LoadModelSettings();
            var defaultModelData = GetDefaultModelData();
            LoadData(SetModelData, defaultModelData);
        }


        private void LoadModelSettings()
        {
            ModelSettings = _settingsManager.GetConfig<TSettings>();
            GameplaySettings = _settingsManager.GetConfig<GameplaySettings>();
        }

        protected void SaveData(TSavableDto data, ESaveLogic saveLogic = ESaveLogic.Now)
        {
            _iSaveSystem.Save(data, saveLogic);
        }

        protected void LoadData(Action<TSavableDto> onDataLoadedCallback, TSavableDto defaultModelData) =>
            _iSaveSystem.LoadDataAsync(onDataLoadedCallback, defaultModelData).Forget();


        protected virtual void SetModelData(TSavableDto data)
        {
            Debug.LogWarning($"set {typeof(TSavableDto).Name} model data");
            ModelData.Value = data;
            SaveData(data);
        }

        protected abstract TSavableDto GetDefaultModelData();
    }
}
