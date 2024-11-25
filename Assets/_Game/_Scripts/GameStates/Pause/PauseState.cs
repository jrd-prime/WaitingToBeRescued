using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.GameStates.Pause
{
    public sealed class PauseState : GameStateBase<IPauseModel, EPauseSubState>
    {
        protected override void OnBaseStateEnter()
        {
            // UIManager.ShowView(EGameState.Pause);
            GameManager.Pause();
        }

        protected override void OnBaseStateExit()
        {
            // UIManager.HideView(EGameState.Pause);
            GameManager.UnPause();
        }

        protected override void InitCustomSubscribes()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
