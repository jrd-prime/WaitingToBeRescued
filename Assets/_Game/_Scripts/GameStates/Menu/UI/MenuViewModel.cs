using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.GameStates.Menu.UI.Base;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Base.ViewModel;
using R3;

namespace _Game._Scripts.GameStates.Menu.UI
{
    public class MenuViewModel : UIViewModelBase<IMenuModel, EMenuSubState>, IMenuViewModel
    {
        public Subject<Unit> BackButtonClicked { get; } = new();
        public Subject<Unit> PlayButtonClicked { get; } = new();
        public Subject<Unit> SettingsButtonClicked { get; } = new();
        public Subject<Unit> ExitButtonClicked { get; } = new();

        public override void Initialize()
        {
            // Main
            PlayButtonClicked.Subscribe(_ => Model.SetGameState(EGameState.Gameplay)).AddTo(Disposables);
            SettingsButtonClicked.Subscribe(_ => Model.SetSubState(EMenuSubState.Settings)).AddTo(Disposables);
            ExitButtonClicked.Subscribe(_ => Model.SetGameState(EGameState.Exit)).AddTo(Disposables);
            // Settings
            BackButtonClicked.Subscribe(_ => Model.SetSubState(EMenuSubState.Main)).AddTo(Disposables);
        }
    }
}
