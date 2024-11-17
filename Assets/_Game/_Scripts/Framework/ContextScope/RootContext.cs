

using System;
using _Game._Scripts.Framework.Input;
using _Game._Scripts.Framework.Managers.Settings;
using _Game._Scripts.Framework.Providers.AssetProvider;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;
using MainSettings = _Game._Scripts.Framework.SO.MainSettings;

namespace _Game._Scripts.Framework.ContextScope
{
    public class RootContext : LifetimeScope
    {
        [SerializeField] private MainSettings mainSettings;
        [SerializeField] private EventSystem eventSystem;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>ROOT CONTEXT</color>");

            if (eventSystem == null) throw new NullReferenceException("EventSystem is null");

            var input = Check(gameObject.AddComponent(typeof(MobileInput)));
            builder.RegisterComponent(input).AsSelf();
            builder.RegisterComponent(eventSystem).AsSelf();
            builder.RegisterComponent(mainSettings).AsSelf();
            builder.Register<AssetProvider>(Lifetime.Singleton).As<IAssetProvider>();
            builder.Register<ISettingsManager, SettingsManager>(Lifetime.Singleton);
        }

        private static T Check<T>(T component) where T : class
        {
            if (component == null) throw new NullReferenceException($"{typeof(T)} is null");
            return component;
        }
    }
}
