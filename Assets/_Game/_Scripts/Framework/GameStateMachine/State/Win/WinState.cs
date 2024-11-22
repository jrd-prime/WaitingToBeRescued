using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Win
{
    public sealed class WinState : GameStateBase<IWinModel<WinSubStateType>>
    {
        protected override void OnMainStateEnter()
        {
            UIManager.ShowView(GameStateType.Win);
            GameManager.StopTheGame();
        }

        protected override void OnMainStateExit()
        {
            UIManager.HideView(GameStateType.Win);
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
