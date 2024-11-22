using _Game._Scripts.Framework.GameStateMachine.State.Menu.SubState;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Menu
{
    public enum MenuSubState
    {
        Main,
        Settings
    }

    public sealed class MenuState : GameStateBase<IMenuModel>
    {
        protected override void InitializeSubStates()
        {
            SubStates.TryAdd(MenuSubState.Main, new MainSubState());
            SubStates.TryAdd(MenuSubState.Settings, new SettingsSubState());

            SetDefaultSubState(MenuSubState.Main);
        }

        protected override void SubscribeToModel()
        {
            
        }

        protected override void OnMainStateEnter()
        {
            if (GameManager.IsGameStarted.CurrentValue) GameManager.GameOver();

            UIManager.ShowView(GameStateType.Menu, true);
            GameManager.Pause();
        }

        protected override void OnMainStateExit()
        {
            UIManager.HideView(GameStateType.Menu);
            GameManager.Pause();
            Debug.LogWarning($"{GetType().Name} exit");
        }
    }
}
