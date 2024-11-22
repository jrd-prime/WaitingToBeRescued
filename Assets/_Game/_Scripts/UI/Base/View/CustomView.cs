using _Game._Scripts.UI.Base.ViewModel;
using VContainer;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class CustomView<T> : ViewBase where T : IUIViewModel
    {
        protected T ViewModel { get; private set; }

        [Inject]
        private void Construct(T viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
