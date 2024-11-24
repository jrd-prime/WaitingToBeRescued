using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.Framework.GameStates.Gameover
{
    public sealed class GameOverState : GameStateBase<IGameoverModel, EGameoverSubState>
    {
        protected override void OnMainStateEnter()
        {
            // UIManager.ShowView(EGameState.GameOver);
            GameManager.GameOver();
        }

        protected override void OnMainStateExit()
        {
            // UIManager.HideView(EGameState.GameOver);
        }

        protected override void SubscribeToModel()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
