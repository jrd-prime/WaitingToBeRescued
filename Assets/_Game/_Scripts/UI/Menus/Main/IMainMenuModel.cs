using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.UI.Menus.Main
{
    public interface IMainMenuModel : IUIModel
    {
        public void PlayButtonClicked();
        public void SettingsButtonClicked();
        public void ExitButtonClicked();
    }
}
