using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JStateMachine._Base;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.Framework.JStateMachine.State.Gameover
{
    public sealed class GameOverState : GameStateBase<IGameoverModel, EGameoverSubState>
    {
        protected override void OnBaseStateEnter()
        {
            // UIManager.ShowView(EGameState.GameOver);
            GameManager.GameOver();
        }

        protected override void OnBaseStateExit()
        {
            // UIManager.HideView(EGameState.GameOver);
        }

        protected override void InitCustomSubscribes()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
