using _Game._Scripts.Framework.Data;
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
            PlayButtonClicked
                .Subscribe(_ => Model.SetGameState(new StateData(EGameState.Gameplay)))
                .AddTo(Disposables);

            SettingsButtonClicked
                .Subscribe(_ => Model.SetGameState(new StateData(EGameState.Menu, EMenuSubState.Settings)))
                .AddTo(Disposables);

            ExitButtonClicked
                .Subscribe(_ => Model.SetGameState(new StateData(EGameState.Exit)))
                .AddTo(Disposables);

            BackButtonClicked
                .Subscribe(_ => Model.SetGameState(new StateData(EGameState.Menu)))
                .AddTo(Disposables);
        }
    }
}
