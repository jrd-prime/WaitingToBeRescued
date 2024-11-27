using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using _Game._Scripts.Framework.Manager.Shelter;
using Cysharp.Threading.Tasks;
using MessagePack;
using MessagePack.Resolvers;
using R3;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace _Game._Scripts.Framework.Systems.SaveLoad
{
    public class MessagePackSaveLoadSystem : ISaveLoadSystem
    {
        public ReactiveProperty<int> LastSaveTime { get; } = new(0);

        private readonly Dictionary<Type, object> _savableData = new();
        private readonly object _lock = new();
        private readonly int saveDelayMs = 5000;
        private readonly string _savePath = Application.dataPath + "/SaveData/";
        private const string FileExtension = ".dat";

        private bool _isRunning;
        private bool _isSaving;

        public void Initialize()
        {
            Debug.LogWarning("SaveLoadSystem initialized");
            _isRunning = true;

            RunSaveLoop().Forget();
        }

        public void Save<TSavableData>(TSavableData data, ESaveLogic saveLogic)
        {
            lock (_lock) _savableData[data.GetType()] = data;

            if (saveLogic == ESaveLogic.Now) SaveNowAsync().Forget();
        }

        public async UniTask LoadDataAsync<TSavableData>(Action<TSavableData> onDataLoadedCallback)
        {
            var filePath = _savePath + typeof(TSavableData).Name + FileExtension;

            await LoadFromFileAsync<TSavableData>(filePath);
            try
            {
                var loadedData = await LoadFromFileAsync<TSavableData>(filePath);
                onDataLoadedCallback.Invoke(loadedData);

                Debug.LogWarning("Data loaded successfully.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to load data: {ex.Message}");
            }
        }

        private async UniTaskVoid RunSaveLoop()
        {
            while (_isRunning)
            {
                await UniTask.Delay(saveDelayMs);
                if (!_isSaving) await SaveNowAsync();
            }
        }

        private async UniTask SaveNowAsync()
        {
            if (_isSaving) return;

            _isSaving = true;

            Dictionary<Type, object> dataToSave;

            lock (_lock) dataToSave = new Dictionary<Type, object>(_savableData);

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                foreach (var savableData in dataToSave)
                {
                    await SaveToFileAsync(savableData.Value, _savePath + savableData.Key.Name + FileExtension);
                }
            }
            finally
            {
                stopwatch.Stop();
                LastSaveTime.Value = (int)stopwatch.ElapsedMilliseconds;

                _isSaving = false;
            }
        }

        private async UniTask SaveToFileAsync<T>(T data, string filePath)
        {
            var directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
                if (directoryPath != null)
                    Directory.CreateDirectory(directoryPath);

            await using var fileStream =
                new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);

            var options = MessagePackSerializerOptions.Standard.WithResolver(StandardResolver.Instance);


            byte[] dataBytes = MessagePackSerializer.Serialize(data, options);

            await fileStream.WriteAsync(dataBytes, 0, dataBytes.Length);
        }

        public async UniTask<T> LoadFromFileAsync<T>(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            await using var fileStream =
                new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);

            var fileData = new byte[fileStream.Length];
            var bytesRead = await fileStream.ReadAsync(fileData, 0, fileData.Length);

            if (bytesRead < fileData.Length) Debug.LogWarning($"Failed to read all bytes from file: {filePath}");

            var options = MessagePackSerializerOptions.Standard.WithResolver(StandardResolver.Instance);

            try
            {
                var loadedData = MessagePackSerializer.Deserialize<T>(fileData, options);
                return loadedData;
            }
            catch (MessagePackSerializationException e)
            {
                Debug.LogError($"Deserialization failed: {e.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            _isRunning = false;
        }
    }
}
