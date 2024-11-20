using R3;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.ViewModel
{
    public abstract class UIViewModelBase : IInitializable
    {
        protected readonly CompositeDisposable Disposables = new();

        public abstract void Initialize();
    }
}
