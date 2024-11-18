using _Game._Scripts.UI;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class GameOverState : GameStateBase, IGameState
    {
        public void Enter()
        {
            UIManager.ShowView(StateType.GameOver);
            GameManager.GameOver();
        }

        public void Exit()
        {
            UIManager.HideView(StateType.GameOver);
        }
    }
}
