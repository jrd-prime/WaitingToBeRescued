using System;
using System.Collections.Generic;
using System.Reflection;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.SO;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Managers.Settings
{
    public class SettingsManager : ISettingsManager
    {
        public string Description => "Config Manager";
        public Dictionary<Type, object> ConfigsCache { get; } = new();

        private MainSettings _mainSettings;

        [Inject]
        private void Construct(MainSettings mainSettings) => _mainSettings = mainSettings;

        public void LoaderServiceInitialization()
        {
            if (_mainSettings == null) throw new NullReferenceException("Main Settings is null");

            AddSettingsToCache();

            Debug.Log("Settings added to cache: " + ConfigsCache.Count);
        }

        private void AddSettingsToCache()
        {
            var fields = typeof(MainSettings)
                .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

            foreach (var field in fields)
            {
                if (!typeof(SettingsSO).IsAssignableFrom(field.FieldType)) continue;
                var settings = (SettingsSO)field.GetValue(_mainSettings);

                if (!ConfigsCache.TryAdd(settings.GetType(), settings))
                    throw new Exception($"Error. When adding to cache {settings.GetType()}");
            }
        }

        public T GetConfig<T>() where T : SettingsSO => ConfigsCache[typeof(T)] as T;
    }
}
