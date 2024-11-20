using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.UI.Menus.Main
{
    public class MainMenuModel : UIModelBase, IMainMenuModel
    {
        public void PlayButtonClicked() => MenuButtonsHandler.PlayButtonClicked();
        public void SettingsButtonClicked() => MenuButtonsHandler.SettingsButtonClicked();
        public void ExitButtonClicked() => MenuButtonsHandler.ExitButtonClicked();

        public override void Initialize()
        {
        }
    }
}
