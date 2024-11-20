using _Game._Scripts.UI.Base.ViewModel;
using R3;

namespace _Game._Scripts.UIOLD.Base
{
    public abstract class UIViewModelBase : IUIViewModel
    {
        protected readonly CompositeDisposable Disposables = new();

        public abstract void Initialize();
    }
}
