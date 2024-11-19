using _Game._Scripts.UI;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class GameOverState : GameStateBase, IGameState
    {
        public void Enter()
        {
            UIController.ShowView(GameStateType.GameOver);
            GameManager.GameOver();
        }

        public void Exit()
        {
            UIController.HideView(GameStateType.GameOver);
        }
    }
}
