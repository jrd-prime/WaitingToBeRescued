using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.GameStates.Win
{
    public sealed class WinState : GameStateBase<IWinModel, EWinSubState>
    {
        protected override void OnMainStateEnter()
        {
            // UIManager.ShowView(EGameState.Win);
            GameManager.StopTheGame();
        }

        protected override void OnMainStateExit()
        {
            // UIManager.HideView(EGameState.Win);
        }

        protected override void SubscribeToModel()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
