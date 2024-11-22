using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UIOLD;
using _Game._Scripts.UIOLD.Menus;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Win
{
    public sealed class WinState : GameStateBase<IWinUIModel>
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
