using R3;
using VContainer.Unity;

namespace _Game._Scripts.UIOLD.Bootstrap
{
    public interface ILoadingScreenViewModel : IInitializable
    {
        public ReactiveProperty<string> TitleText { get; }
    }
}
