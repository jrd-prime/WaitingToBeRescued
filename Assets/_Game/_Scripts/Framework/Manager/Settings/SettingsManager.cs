using System;
using System.Collections.Generic;
using System.Reflection;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO._Base;
using _Game._Scripts.Framework.Data.SO.Game;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.Settings
{
    public class SettingsManager : ISettingsManager
    {
        public string Description => "Settings Manager";
        public Dictionary<Type, object> ConfigsCache { get; } = new();

        private MainSettings _mainSettings;

        [Inject]
        private void Construct(MainSettings mainSettings) => _mainSettings = mainSettings;

        public void LoaderServiceInitialization()
        {
            if (_mainSettings == null) throw new NullReferenceException("Main Settings is null");

            AddSettingsToCache();
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

                Debug.Log("Settings added to cache: " + settings.GetType().Name);
            }

            Debug.Log("Settings count: " + ConfigsCache.Count);
        }

        public T GetConfig<T>() where T : SettingsSO
        {
            if (!ConfigsCache.ContainsKey(typeof(T))) throw new Exception($"Settings {typeof(T).Name} not found");

            return ConfigsCache[typeof(T)] as T;
        }
    }
}
