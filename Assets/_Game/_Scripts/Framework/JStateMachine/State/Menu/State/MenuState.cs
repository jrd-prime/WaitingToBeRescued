using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JStateMachine._Base;
using _Game._Scripts.Framework.JStateMachine.State.Menu.State.SubState;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.Framework.JStateMachine.State.Menu.State
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

        protected override void InitCustomSubscribes()
        {
        }

        protected override void OnBaseStateEnter()
        {
        }

        protected override void OnBaseStateExit()
        {
        }
    }
}
