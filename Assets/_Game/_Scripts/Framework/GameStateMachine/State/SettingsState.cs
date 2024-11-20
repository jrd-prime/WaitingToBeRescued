using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class SettingsState : GameStateBase, IGameState
    {
        public void Enter()
        {
            Debug.LogWarning("s ettings state enter");
            UIController.ShowView(GameStateType.Settings);
        }

        public void Exit()
        {
            Debug.LogWarning("settings state exit");
            UIController.HideView(GameStateType.Settings);
        }
    }
}
