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
            SubStates.TryAdd(EMenuSubState.Main, new MainSubState(UIManager));
            SubStates.TryAdd(EMenuSubState.Settings, new SettingsSubState(UIManager));

            SetDefaultSubState(EMenuSubState.Main);
        }

        protected override void SubscribeToModel()
        {
            Model.CurrentSubState
                .Subscribe(ChangeSubState)
                .AddTo(Disposables);
        }

        protected override void OnMainStateEnter()
        {
            // if (GameManager.IsGameStarted.CurrentValue) GameManager.GameOver();
            //
            // GameManager.Pause();
        }

        protected override void OnMainStateExit()
        {
            // GameManager.Pause();
        }
    }
}
