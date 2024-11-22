using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.UI.Menu.Base
{
    public interface IMenuModel : IUIModel
    {
        public void PlayButtonClicked();
        public void SettingsButtonClicked();
        public void ExitButtonClicked();
    }
}
