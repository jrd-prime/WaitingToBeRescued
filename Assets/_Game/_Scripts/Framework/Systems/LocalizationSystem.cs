using System;
using System.Collections.Generic;
using _Game._Scripts.Bootstrap;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Game._Scripts.Framework.Systems
{
    public class LocalizationSystem : ILocalizationSystem
    {
        private const string RU = "ru";
        private const string EN = "en";

        private readonly Dictionary<string, string> _dictionary = new();
        private ILoadingOperation _iLoadingOperationImplementation;

        public string GetString(string key)
        {
            Debug.LogWarning("get string: " + key);
            return _dictionary[key];
        }

        public string Description => "Localization System";

        public async void LoaderServiceInitialization()
        {
            Debug.LogWarning("Localization system initialization. Default language: " + RU);

            await LoadLocalizationDataAsync(RU);
        }

        private async UniTask LoadLocalizationDataAsync(string address)
        {
            try
            {
                var handle = Addressables.LoadAssetAsync<TextAsset>(address);
                var textAsset = await handle.Task;

                if (textAsset != null)
                {
                    var jsonContent = textAsset.text;
                    var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);

                    foreach (var entry in data)
                    {
                        _dictionary.TryAdd(entry.Key, entry.Value);
                    }

                    Debug.Log("Localization data loaded successfully.");
                }
                else
                {
                    Debug.LogError($"Localization file not found at address: {address}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to load localization data: {ex.Message}");
            }
        }
    }

    public interface ILocalizationSystem : ILoadingOperation
    {
        public string GetString(string key);
    }
}
