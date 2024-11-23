using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.UI;

namespace _Game._Scripts.Framework.GameStateMachine.State.Menu.SubState
{
    public class MainSubState : SubStateBase
    {
        public MainSubState(IUIManager uiManager) : base(uiManager)
        {
        }

        public override void Enter()
        {
            CurrentSubState = EMenuSubState.Main;
            UIManager.ShowView(EGameState.Menu, CurrentSubState, true);
        }

        public override void Exit()
        {
            UIManager.HideView(EGameState.Menu, CurrentSubState);
        }
    }
}
