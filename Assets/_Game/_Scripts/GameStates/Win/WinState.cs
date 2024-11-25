using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.GameStates.Win
{
    public sealed class WinState : GameStateBase<IWinModel, EWinSubState>
    {
        protected override void OnBaseStateEnter()
        {
            // UIManager.ShowView(EGameState.Win);
            GameManager.StopTheGame();
        }

        protected override void OnBaseStateExit()
        {
            // UIManager.HideView(EGameState.Win);
        }

        protected override void InitCustomSubscribes()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
