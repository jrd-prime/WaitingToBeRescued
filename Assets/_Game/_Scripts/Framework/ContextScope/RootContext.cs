using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Attributes;
using _Game._Scripts.Framework.Input;
using _Game._Scripts.Framework.Managers.Settings;
using _Game._Scripts.Framework.Providers.AssetProvider;
using _Game._Scripts.Framework.SO;
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

            builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
            builder.Register<ISettingsManager, SettingsManager>(Lifetime.Singleton);
        }
    }
}
