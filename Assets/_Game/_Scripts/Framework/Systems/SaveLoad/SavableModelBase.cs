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

        private ISaveSystem _saveSystem;

        private bool _isAddedToAutoSave = false;


        [Inject]
        private void Construct(ISaveSystem iSaveSystem, ISettingsManager settingsManager)
        {
            _saveSystem = iSaveSystem;
            _settingsManager = settingsManager;
        }

        public void Initialize()
        {
            LoadModelSettings();
            var defaultModelData = GetDefaultModelData();
            _saveSystem.LoadDataAsync(SetNewModelData, defaultModelData).Forget();
        }

        private void LoadModelSettings()
        {
            ModelSettings = _settingsManager.GetConfig<TSettings>();
            GameplaySettings = _settingsManager.GetConfig<GameplaySettings>();
        }

        public virtual void SetNewModelData(TSavableDto data)
        {
            Debug.LogWarning("End loading data: " + typeof(TSavableDto).Name);

            ModelData.Value = data;
            ModelData.ForceNotify();

            if (_isAddedToAutoSave) return;
            ShowDebug();
            _saveSystem.Save(data, ESaveLogic.Periodic);
            _isAddedToAutoSave = true;
        }

        protected abstract void ShowDebug();

        protected abstract TSavableDto GetDefaultModelData();
    }
}
