using _Game._Scripts.UIOLD;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class GamePlayState : GameStateBase, IGameState
    {
        public void Enter()
        {
            UIManager.ShowView(GameStateType.Gameplay);
            GameManager.StartNewGame();
            PlayerModel.SetGameStarted(true);
            
        }

        public void Exit()
        {
            UIManager.HideView(GameStateType.Gameplay);
            PlayerModel.SetGameStarted(false);
        }
    }
}
