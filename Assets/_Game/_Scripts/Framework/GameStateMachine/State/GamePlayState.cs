using _Game._Scripts.UI;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class GamePlayState : GameStateBase, IGameState
    {
        public void Enter()
        {
            UIController.ShowView(GameStateType.Gameplay);
            GameManager.StartNewGame();
            PlayerModel.SetGameStarted(true);
            
        }

        public void Exit()
        {
            UIController.HideView(GameStateType.Gameplay);
            PlayerModel.SetGameStarted(false);
        }
    }
}
