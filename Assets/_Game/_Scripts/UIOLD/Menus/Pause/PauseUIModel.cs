using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.UIOLD.Menus.Pause
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
            UIManager.ShowPopUpAsync("Low priority. Will be implemented later.",333);
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
