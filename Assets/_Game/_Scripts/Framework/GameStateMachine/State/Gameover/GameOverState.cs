using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Gameplay;
using _Game._Scripts.UI.Menu.Base;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Gameover
{
    public sealed class GameOverState : GameStateBase<IGameoverModel, EGameoverSubState>
    {
        protected override void OnMainStateEnter()
        {
            UIManager.ShowView(EGameState.GameOver);
            GameManager.GameOver();
        }

        protected override void OnMainStateExit()
        {
            UIManager.HideView(EGameState.GameOver);
        }

        protected override void SubscribeToModel()
        {
        }

        protected override void InitializeSubStates()
        {
            Debug.LogWarning("implement me");
        }
    }
}
