using _Game._Scripts.UI.Base.ViewModel;
using R3;

namespace _Game._Scripts.UI.Menus.Main
{
    public interface IMainMenuViewModel : IUIViewModel
    {
        public Subject<Unit> PlayButtonClicked { get; }
        public Subject<Unit> SettingsButtonClicked { get; }
        public Subject<Unit> ExitButtonClicked { get; }
    }
}
