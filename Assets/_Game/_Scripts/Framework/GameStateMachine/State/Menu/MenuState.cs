using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine.State.Menu.SubState;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine;

namespace _Game._Scripts.Framework.GameStateMachine.State.Menu
{
    public sealed class MenuState : GameStateBase<IMenuModel, EMenuSubState>
    {
        protected override void InitializeSubStates()
        {
            SubStates.TryAdd(EMenuSubState.Main, new MainSubState());
            SubStates.TryAdd(EMenuSubState.Settings, new SettingsSubState());

            SetDefaultSubState(EMenuSubState.Main);
        }

        protected override void SubscribeToModel()
        {
            Model.CurrentSubState.Subscribe(ChangeSubState).AddTo(Disposables);
        }

        protected override void OnMainStateEnter()
        {
            if (GameManager.IsGameStarted.CurrentValue) GameManager.GameOver();

            UIManager.ShowView(EGameState.Menu, true);
            GameManager.Pause();
        }

        protected override void OnMainStateExit()
        {
            UIManager.HideView(EGameState.Menu);
            GameManager.Pause();
            Debug.LogWarning($"{GetType().Name} exit");
        }
    }
}
