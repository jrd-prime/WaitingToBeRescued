using System;
using _Game._Scripts.Bootstrap;
using _Game._Scripts.Framework.Const;
using _Game._Scripts.Framework.Managers.Settings;
using _Game._Scripts.Framework.Providers.AssetProvider;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts
{
    public sealed class AppStarter : IInitializable
    {
        private ILoader _loader;
        private IAssetProvider _assetProvider;
        private ISettingsManager _settingsManager;

        [Inject]
        private void Construct(IObjectResolver container)
        {
            _loader = container.Resolve<ILoader>();
            _assetProvider = container.Resolve<IAssetProvider>();
            _settingsManager = container.Resolve<ISettingsManager>();
        }

        public async void Initialize()
        {
            if (_loader == null) throw new NullReferenceException("Loader is null.");
            if (_assetProvider == null) throw new NullReferenceException("AssetProvider is null.");
            if (_settingsManager == null) throw new NullReferenceException("SettingsManager is null.");

            _loader.AddServiceForInitialization(_assetProvider);
            _loader.AddServiceForInitialization(_settingsManager);

            Debug.Log("Starting services initialization...");
            await _loader.StartServicesInitializationAsync();
            Debug.Log("Services initialization completed...");

            SceneInstance gameScene;
            try
            {
                gameScene = await _assetProvider.LoadSceneAsync(AssetsConst.GameScene, LoadSceneMode.Additive);
            }
            catch
                (Exception ex)
            {
                throw new Exception($"Failed to load game scene: {ex.Message}");
            }

            // TODO FadeOut loading screen view 
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.SetActiveScene(gameScene.Scene);
            await SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
