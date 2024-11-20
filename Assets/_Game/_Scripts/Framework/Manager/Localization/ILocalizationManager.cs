using _Game._Scripts.Bootstrap;

namespace _Game._Scripts.Framework.Manager.Localization
{
    public interface ILocalizationManager : ILoadingOperation
    {
        public string GetString(string key);
    }
}
