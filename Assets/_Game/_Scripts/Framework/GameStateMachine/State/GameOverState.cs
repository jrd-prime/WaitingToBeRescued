using _Game._Scripts.UIOLD;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class GameOverState : GameStateBase, IGameState
    {
        public void Enter()
        {
            UIManager.ShowView(GameStateType.GameOver);
            GameManager.GameOver();
        }

        public void Exit()
        {
            UIManager.HideView(GameStateType.GameOver);
        }
    }
}
