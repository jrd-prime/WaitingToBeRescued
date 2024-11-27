using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Input;
using _Game._Scripts.Framework.Manager.Localization;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Framework.Providers.AssetProvider;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.Framework.Systems.SaveLoad;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class RootContext : LifetimeScope
    {
        [RequiredField, SerializeField] private MainSettings mainSettings;
        [RequiredField, SerializeField] private EventSystem eventSystem;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>Root context</color>");

            if (mainSettings == null) throw new NullReferenceException("MainSettings is null");
            if (eventSystem == null) throw new NullReferenceException("EventSystem is null");

            var input = gameObject.AddComponent(typeof(MobileInput)) ??
                        throw new NullReferenceException("MobileInput is null");
            builder.RegisterComponent(input).AsSelf();

            builder.RegisterComponent(eventSystem).AsSelf();
            builder.RegisterComponent(mainSettings).AsSelf();

            builder.Register<ISaveLoadSystem, MessagePackSaveLoadSystem>(Lifetime.Singleton)
                .As<IInitializable, IDisposable>();

            builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
            builder.Register<ISettingsManager, SettingsManager>(Lifetime.Singleton);
            builder.Register<ILocalizationManager, LocalizationManager>(Lifetime.Singleton);
        }
    }
}
