using _Game._Scripts.UI.Base.ViewModel;
using R3;

namespace _Game._Scripts.UI.Menus.Main
{
    public class MainMenuUIViewModel : CustomUIViewModel<IMainMenuModel>, IMainMenuViewModel
    {
        public Subject<Unit> PlayButtonClicked { get; } = new();
        public Subject<Unit> SettingsButtonClicked { get; } = new();
        public Subject<Unit> ExitButtonClicked { get; } = new();


        public override void Initialize()
        {
            PlayButtonClicked.Subscribe(_ => Model.PlayButtonClicked()).AddTo(Disposables);
            SettingsButtonClicked.Subscribe(_ => Model.SettingsButtonClicked()).AddTo(Disposables);
            ExitButtonClicked.Subscribe(_ => Model.ExitButtonClicked()).AddTo(Disposables);
        }
    }
}
