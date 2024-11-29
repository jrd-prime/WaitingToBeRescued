using System;
using System.Collections.Generic;
using _Game._Scripts.Bootstrap;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Game._Scripts.Framework.Manager.Localization
{
    public class LocalizationManager : ILocalizationManager
    {
        public string Description => "Localization System";

        private const string RU = "ru";
        private const string EN = "en";

        private const string DefaultLanguage = EN;

        private readonly Dictionary<string, string> _dictionary = new();
        private ILoadingOperation _iLoadingOperationImplementation;

        public string GetString(string key)
        {
            if (!_dictionary.TryGetValue(key, out var s))
                throw new KeyNotFoundException($"Localization key '{key}' not found.");
            return s;
        }

        public async void LoaderServiceInitialization()
        {
            try
            {
                await LoadLocalizationDataAsync(DefaultLanguage);

                Debug.Log("Localization system initialization completed. Default language: " + DefaultLanguage);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load localization data: {e.Message}");
            }
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

                    foreach (var entry in data) _dictionary.TryAdd(entry.Key, entry.Value);
                }
                else Debug.LogError($"Localization file not found at address: {address}");
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load localization data: {e.Message}");
            }
        }
    }
}
