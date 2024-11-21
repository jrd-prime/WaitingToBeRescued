using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class MenuState : GameStateBase, IGameState
    {
        public void Enter()
        {
            Debug.LogWarning(" menu state enterm");
            if (GameManager.IsGameStarted.CurrentValue) GameManager.GameOver();

            UIManager.ShowView(GameStateType.Menu, true);
            GameManager.Pause();
        }

        public void Exit()
        {
            UIManager.HideView(GameStateType.Menu);
            GameManager.Pause();
        }
    }
}
