using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Menu.Base;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Win
{
    public sealed class WinState : GameStateBase<IWinModel, EWinSubState>
    {
        protected override void OnMainStateEnter()
        {
            // UIManager.ShowView(EGameState.Win);
            GameManager.StopTheGame();
        }

        protected override void OnMainStateExit()
        {
            // UIManager.HideView(EGameState.Win);
        }

        protected override void SubscribeToModel()
        {
        }

        protected override void InitializeSubStates()
        {
        }
    }
}
