using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Gameplay;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Gameover
{
    public sealed class GameOverState : GameStateBase<IGameoverModel<GameplaySubStateType>>
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
