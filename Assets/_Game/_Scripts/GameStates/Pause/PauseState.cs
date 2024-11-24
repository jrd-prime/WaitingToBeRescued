using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.GameStates.Pause
{
    public sealed class PauseState : GameStateBase<IPauseModel, EPauseSubState>
    {
        protected override void OnMainStateEnter()
        {
            // UIManager.ShowView(EGameState.Pause);
            GameManager.Pause();
        }

        protected override void OnMainStateExit()
        {
            // UIManager.HideView(EGameState.Pause);
            GameManager.UnPause();
        }

        protected override void SubscribeToModel()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
