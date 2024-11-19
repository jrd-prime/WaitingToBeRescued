using _Game._Scripts.UI;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class MenuState : GameStateBase, IGameState
    {
        public void Enter()
        {
            Debug.LogWarning(" menu state enterm");
            if (GameManager.IsGameStarted.CurrentValue) GameManager.GameOver();

            UIController.ShowView(GameStateType.Menu);
        }

        public void Exit()
        {
            UIController.HideView(GameStateType.Menu);
        }
    }
}
