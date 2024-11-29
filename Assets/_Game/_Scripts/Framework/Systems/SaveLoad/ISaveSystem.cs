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
        public UniTask LoadDataAsync<T>(Action<T> setModelData, T defaultData);
        public  UniTask SaveToFileAsync<T>(T data);
    }
}
