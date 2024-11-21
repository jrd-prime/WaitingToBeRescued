using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State
{
    public sealed class SettingsState : GameStateBase, IGameState
    {
        public void Enter()
        {
            Debug.LogWarning("s ettings state enter");
            UIManager.ShowView(GameStateType.Settings);
        }

        public void Exit()
        {
            Debug.LogWarning("settings state exit");
            UIManager.HideView(GameStateType.Settings);
        }
    }
}
