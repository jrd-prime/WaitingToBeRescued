using _Game._Scripts.Framework.Const;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace _Game._Scripts.Framework.Providers.AssetProvider
{
    public sealed class AssetProvider : IAssetProvider
    {
        public string Description => "Asset Provider";

        public void LoaderServiceInitialization() => Addressables.InitializeAsync();
        
        public async UniTask<SceneInstance> LoadSceneAsync(string assetId, LoadSceneMode loadSceneMode)
        {
            return await Addressables.LoadSceneAsync(AssetsConst.GameScene, loadSceneMode).Task;
        }

        public async UniTask<GameObject> InstantiateAsync(AssetReference assetId, Transform parent = null)
        {
            var handle = Addressables.InstantiateAsync(assetId, parent);
            return await handle.Task;
        }
    }
}
