using R3;

namespace _Game._Scripts.NewUI.Menus.Main
{
    public interface IUINewViewModel
    {
    }

    public interface IMainMenu_ViewModel : IUINewViewModel
    {
        public Subject<Unit> PlayButtonClicked { get; }
        public Subject<Unit> SettingsButtonClicked { get; }
        public Subject<Unit> ExitButtonClicked { get; }
    }
}
