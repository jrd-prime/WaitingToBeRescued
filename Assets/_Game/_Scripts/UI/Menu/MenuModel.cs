using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using R3;

namespace _Game._Scripts.UI.Menu
{
    public class MenuModel : UIModelBase, IMenuModel<MenuSubStateType>
    {
        public ReactiveProperty<MenuSubStateType> CurrentSubState { get; } = new(MenuSubStateType.Main);
        public ReactiveProperty<GameStateType> GameState { get; } = new();

        public override void Initialize()
        {
        }
    }
}
