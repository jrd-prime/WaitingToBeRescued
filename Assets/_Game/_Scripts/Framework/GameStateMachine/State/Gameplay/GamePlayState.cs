using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Gameplay;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Gameplay
{public enum GameplaySubStateType{}
    public enum GameoverSubStateType{}
    public enum PauseSubStateType{}
    public enum WinSubStateType{}
    public sealed class GamePlayState : GameStateBase<IGameplayModel<GameplaySubStateType>>
    {
        protected override void OnMainStateEnter()
        {
            UIManager.ShowView(GameStateType.Gameplay);
            GameManager.StartNewGame();
            PlayerModel.SetGameStarted(true);
        }

        protected override void OnMainStateExit()
        {
            UIManager.HideView(GameStateType.Gameplay);
            PlayerModel.SetGameStarted(false);
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
