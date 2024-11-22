using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Base.ViewModel;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using R3;

namespace _Game._Scripts.UI.Menu
{
    public class MenuViewModel : CustomUIViewModel<IMenuModel<MenuSubStateType>, MenuSubStateType>, IMenuViewModel
    {
        public Subject<Unit> PlayButtonClicked { get; } = new();
        public Subject<Unit> SettingsButtonClicked { get; } = new();
        public Subject<Unit> ExitButtonClicked { get; } = new();


        public override void Initialize()
        {
            PlayButtonClicked.Subscribe(_ => Model.SetGameState(GameStateType.Gameplay)).AddTo(Disposables);
            SettingsButtonClicked.Subscribe(_ => Model.SetSubState(MenuSubStateType.Settings)).AddTo(Disposables);
            ExitButtonClicked.Subscribe(_ => Model.SetGameState(GameStateType.Exit)).AddTo(Disposables);
        }
    }
}
