using _Game._Scripts.UIOLD;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class PauseState : GameStateBase, IGameState
    {
        public void Enter()
        {
            UIManager.ShowView(GameStateType.Pause);
            GameManager.Pause();
        }

        public void Exit()
        {
            UIManager.HideView(GameStateType.Pause);
            GameManager.UnPause();
        }
    }
}
