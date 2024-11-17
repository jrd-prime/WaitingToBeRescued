using _Game._Scripts.Bootstrap;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace _Game._Scripts.Framework.Providers.AssetProvider
{
    public interface IAssetProvider : ILoadingOperation
    {
        public UniTask<SceneInstance> LoadSceneAsync(string assetId, LoadSceneMode loadSceneMode);
        public UniTask<GameObject> InstantiateAsync(AssetReference assetId, Transform parent = null);
    }
}
