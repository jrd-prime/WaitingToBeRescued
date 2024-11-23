using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Base.ViewModel;
using _Game._Scripts.UI.Menu.Base;
using R3;

namespace _Game._Scripts.UI.Menu
{
    public class MenuViewModel : UIViewModelBase<IMenuModel, EMenuSubState>, IMenuViewModel
    {
        public Subject<Unit> PlayButtonClicked { get; } = new();
        public Subject<Unit> SettingsButtonClicked { get; } = new();
        public Subject<Unit> ExitButtonClicked { get; } = new();


        public override void Initialize()
        {
            PlayButtonClicked.Subscribe(_ => Model.SetGameState(EGameState.Gameplay)).AddTo(Disposables);
            SettingsButtonClicked.Subscribe(_ => Model.SetSubState(EMenuSubState.Settings)).AddTo(Disposables);
            ExitButtonClicked.Subscribe(_ => Model.SetGameState(EGameState.Exit)).AddTo(Disposables);
        }
    }
}
