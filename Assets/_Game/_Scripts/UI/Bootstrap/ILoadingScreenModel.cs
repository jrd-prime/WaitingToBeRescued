using System;
using R3;

namespace _Game._Scripts.UI.Bootstrap
{
    public interface ILoadingScreenModel : IDisposable
    {
        public ReactiveProperty<string> LoadingText { get; }
        public void SetLoadingText(string value);
    }
}
