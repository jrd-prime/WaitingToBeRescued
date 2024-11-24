using _Game._Scripts.UI.Base.ViewModel;
using R3;

namespace _Game._Scripts.GameStates.Menu.UI.Base
{
    public interface IMenuViewModel : IUIViewModel
    {
        public Subject<Unit> BackButtonClicked { get; }
        public Subject<Unit> PlayButtonClicked { get; }
        public Subject<Unit> SettingsButtonClicked { get; }
        public Subject<Unit> ExitButtonClicked { get; }
    }
}
