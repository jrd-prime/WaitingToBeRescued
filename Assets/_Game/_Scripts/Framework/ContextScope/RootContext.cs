using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers.Editor;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Input;
using _Game._Scripts.Framework.Manager.Localization;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Framework.Providers.AssetProvider;
using _Game._Scripts.Framework.Systems.SaveLoad;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;
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

            builder.Register<ISaveSystem, MessagePackISaveSystem>(Lifetime.Singleton)
                .As<IInitializable, IDisposable>();

            builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
            builder.Register<ISettingsManager, SettingsManager>(Lifetime.Singleton);
            builder.Register<ILocalizationManager, LocalizationManager>(Lifetime.Singleton);
        }

        private void OnApplicationQuit()
        {
            Debug.Log("On Application Quit");
            Debug.Log("<color=darkblue><b>=======================</b></color>");
            var rendTex = (RenderTexture[])Resources.FindObjectsOfTypeAll(typeof(RenderTexture));

            Debug.Log($"Render Textures: {rendTex.Length}");
            var i = 0;
            foreach (var t in rendTex)
                if (t.name.StartsWith("Device Simulator"))
                {
                    Destroy(t);
                    i++;
                }

            Debug.Log($"Render Textures Destroyed: {i}");
            Debug.Log("<color=darkblue><b>=======================</b></color>");
            Debug.Log($"Total Allocated: {Profiler.GetTotalAllocatedMemoryLong() / (1024 * 1024)} MB");
            Debug.Log($"Total Reserved: {Profiler.GetTotalReservedMemoryLong() / (1024 * 1024)} MB");
            Debug.Log($"Total Unused Reserved: {Profiler.GetTotalUnusedReservedMemoryLong() / (1024 * 1024)} MB");
            Debug.Log("<color=darkblue><b>=======================</b></color>");
            DeleteSavesMenu.DeleteSaves();
        }
    }
}
