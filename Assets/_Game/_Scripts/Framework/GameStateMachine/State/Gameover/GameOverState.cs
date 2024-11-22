using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UIOLD;
using _Game._Scripts.UIOLD.Menus;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Gameover
{
    public enum GameoverSubState
    {
        Main
    }

    public sealed class GameOverState : GameStateBase<IGameoverUIModel>
    {
        protected override void OnMainStateEnter()
        {
            UIManager.ShowView(GameStateType.GameOver);
            GameManager.GameOver();
        }

        protected override void OnMainStateExit()
        {
            UIManager.HideView(GameStateType.GameOver);
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
