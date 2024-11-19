using _Game._Scripts.UI.Base;
using _Game._Scripts.UI.Interfaces;

namespace _Game._Scripts.UI.Menus.Pause
{
    public class PauseUIModel : UIModelBase, IPauseUIModel
    {
        public void ContinueButtonClicked()
        {
            StateMachine.ChangeStateTo(GameStateType.Gameplay);
        }

        public void SettingsButtonClicked()
        {
            // StateMachine.ChangeStateTo(UIType.Settings);
            UIManager.ShowPopUpAsync("Low priority. Will be implemented later.");
        }

        public void ToMainMenuButtonClicked()
        {
            StateMachine.ChangeStateTo(GameStateType.Menu);
        }

        public override void Initialize()
        {
            
        }
    }

    public interface IPauseUIModel : IUIModel
    {
        public void ContinueButtonClicked();
        public void SettingsButtonClicked();
        public void ToMainMenuButtonClicked();
    }
}
