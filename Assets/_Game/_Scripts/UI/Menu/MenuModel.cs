using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Menu.Base;

namespace _Game._Scripts.UI.Menu
{
    public class MenuModel : UIModelBase, IMenuModel
    {
        public void PlayButtonClicked() => MenuButtonsHandler.PlayButtonClicked();
        public void SettingsButtonClicked() => MenuButtonsHandler.SettingsButtonClicked();
        public void ExitButtonClicked() => MenuButtonsHandler.ExitButtonClicked();

        public override void Initialize()
        {
        }
    }
}
