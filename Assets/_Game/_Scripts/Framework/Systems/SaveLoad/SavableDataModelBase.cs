using System;
using _Game._Scripts.Framework.Manager.Shelter;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Systems.SaveLoad
{
    public abstract class SavableDataModelBase<TSavableData> : IInitializable
    {
        public ReactiveProperty<TSavableData> ModelData { get; } = new();

        private ISaveLoadSystem _saveLoadSystem;

        [Inject]
        private void Construct(ISaveLoadSystem saveLoadSystem) => _saveLoadSystem = saveLoadSystem;

        public void Initialize()
        {
            LoadData(SetModelData);
        }

        protected void SaveData(TSavableData data, ESaveLogic saveLogic = ESaveLogic.Now)
        {
            _saveLoadSystem.Save(data, saveLogic);
        }

        protected void LoadData(Action<TSavableData> onDataLoadedCallback) =>
            _saveLoadSystem.LoadDataAsync(onDataLoadedCallback).Forget();


        protected virtual void SetModelData(TSavableData data)
        {
            Debug.LogWarning($"set {typeof(TSavableData).Name} model data");
            ModelData.Value = data;
            SaveData(data);
        }
    }
}
