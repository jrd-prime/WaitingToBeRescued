using _Game._Scripts.Framework.GameStateMachine.State.Menu.SubState;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Menu
{
    public enum MenuSubStateType
    {
        Main,
        Settings
    }

    public sealed class MenuState : GameStateBase<IMenuModel<MenuSubStateType>>
    {
        protected override void InitializeSubStates()
        {
            SubStates.TryAdd(MenuSubStateType.Main, new MainSubState());
            SubStates.TryAdd(MenuSubStateType.Settings, new SettingsSubState());

            SetDefaultSubState(MenuSubStateType.Main);
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
