using _Game._Scripts.UI.Base;
using _Game._Scripts.UI.Interfaces;

namespace _Game._Scripts.UI.Pause
{
    public class PauseUIModel : UIModelBase, IPauseUIModel
    {
        public void ContinueButtonClicked()
        {
            StateMachine.ChangeStateTo(StateType.Game);
        }

        public void SettingsButtonClicked()
        {
            // StateMachine.ChangeStateTo(UIType.Settings);
            UIManager.ShowPopUpAsync("Low priority. Will be implemented later.");
        }

        public void ToMainMenuButtonClicked()
        {
            StateMachine.ChangeStateTo(StateType.Menu);
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
