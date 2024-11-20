using Cysharp.Threading.Tasks;

namespace _Game._Scripts.Bootstrap
{
    public interface ILoader
    {
        public void AddServiceForInitialization(ILoadingOperation loadingService);
        public UniTask StartServicesInitializationAsync();
    }
}