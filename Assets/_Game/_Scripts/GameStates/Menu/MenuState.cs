using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.GameStates.Menu.SubState;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine;

namespace _Game._Scripts.GameStates.Menu
{
    public class MenuState : GameStateBase<IMenuModel, EMenuSubState>
    {
        protected override void InitializeSubStates()
        {
            SubStatesCache.TryAdd(EMenuSubState.Main,
                new MenuMainSubState(UIManager, EGameState.Menu, EMenuSubState.Main));
            SubStatesCache.TryAdd(EMenuSubState.Settings,
                new MenuSettingsSubState(UIManager, EGameState.Menu, EMenuSubState.Settings));
        }

        protected override void SubscribeToModel()
        {
            Model.CurrentSubState
                .Subscribe(ChangeSubState)
                .AddTo(Disposables);
            Model.GameState.Subscribe(x => ChangeState(x)).AddTo(Disposables);
        }

        private void ChangeState(EGameState eGameState)
        {
            Debug.LogWarning("change state in menu " + eGameState);
            ChangeStateCallback.Invoke(eGameState);
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
