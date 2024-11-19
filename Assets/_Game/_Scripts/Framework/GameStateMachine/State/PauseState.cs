using _Game._Scripts.UI;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class PauseState : GameStateBase, IGameState
    {
        public void Enter()
        {
            UIController.ShowView(GameStateType.Pause);
            GameManager.Pause();
        }

        public void Exit()
        {
            UIController.HideView(GameStateType.Pause);
            GameManager.UnPause();
        }
    }
}
