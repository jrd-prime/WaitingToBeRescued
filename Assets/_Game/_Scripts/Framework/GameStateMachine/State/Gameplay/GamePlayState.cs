using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Gameplay;
using _Game._Scripts.UI.Menu.Base;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Gameplay
{
    public sealed class GamePlayState : GameStateBase<IGameplayModel, EGameplaySubState>
    {
        protected override void OnMainStateEnter()
        {
            // UIManager.ShowView(EGameState.Gameplay);
            GameManager.StartNewGame();
            PlayerModel.SetGameStarted(true);
        }

        protected override void OnMainStateExit()
        {
            // UIManager.HideView(EGameState.Gameplay);
            PlayerModel.SetGameStarted(false);
        }

        protected override void SubscribeToModel()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
