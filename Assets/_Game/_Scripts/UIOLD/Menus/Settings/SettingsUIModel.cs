using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.UIOLD.Menus.Settings
{
    public interface ISettingsUIModel : IUIModel
    {
        public void MusicButtonClicked();
        public void VfxButtonClicked();
        public void MenuButtonClicked();
    }

    public class SettingsUIModel : UIModelBase, ISettingsUIModel
    {
        public void MusicButtonClicked()
        {
            // TODO : sound manager on/off music
            UIManager.ShowPopUpAsync("Low priority. Will be implemented later.", 333);
        }

        public void VfxButtonClicked()
        {
            // TODO : sound manager on/off vfx
            UIManager.ShowPopUpAsync("Low priority. Will be implemented later.", 333);
        }

        public void MenuButtonClicked()
        {
            StateMachine.ChangeStateTo(GameStateType.Menu);
        }

        public override void Initialize()
        {
        }
    }
}
