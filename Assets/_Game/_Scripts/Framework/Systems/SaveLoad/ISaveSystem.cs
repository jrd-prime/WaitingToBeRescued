using System;
using _Game._Scripts.Framework.Manager.Shelter;
using Cysharp.Threading.Tasks;
using R3;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Systems.SaveLoad
{
    public interface ISaveSystem : IInitializable, IDisposable
    {
        public ReactiveProperty<int> LastSaveTime { get; }
        public void Save<TSavableData>(TSavableData data, ESaveLogic saveLogic = ESaveLogic.Now);
        public UniTask<T> LoadFromFileAsync<T>(string filePath);
        public UniTask LoadDataAsync<T>(Action<T> setModelData, T defaultData);
        public void SavePeriodicalData();
    }
}
