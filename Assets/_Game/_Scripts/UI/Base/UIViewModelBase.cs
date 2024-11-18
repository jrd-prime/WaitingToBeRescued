using _Game._Scripts.UI.Interfaces;
using R3;

namespace _Game._Scripts.UI.Base
{
    public abstract class UIViewModelBase : IUIViewModel
    {
        protected readonly CompositeDisposable Disposables = new();

        public abstract void Initialize();
    }
}
