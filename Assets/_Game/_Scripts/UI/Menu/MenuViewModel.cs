using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Base.ViewModel;
using _Game._Scripts.UI.Menu.Base;
using R3;
using UnityEngine;

namespace _Game._Scripts.UI.Menu
{
    public class MenuViewModel : UIViewModelBase<IMenuModel, EMenuSubState>, IMenuViewModel
    {
        public Subject<Unit> BackButtonClicked { get; } = new();
        public Subject<Unit> PlayButtonClicked { get; } = new();
        public Subject<Unit> SettingsButtonClicked { get; } = new();
        public Subject<Unit> ExitButtonClicked { get; } = new();


        public override void Initialize()
        {
            PlayButtonClicked.Subscribe(_ =>
            {
                Model.SetGameState(EGameState.Gameplay);
                Debug.LogWarning("cli play");
            }).AddTo(Disposables);
            SettingsButtonClicked.Subscribe(_ =>
            {
                Model.SetSubState(EMenuSubState.Settings);
                Debug.LogWarning("cli settings");
            }).AddTo(Disposables);
            ExitButtonClicked.Subscribe(_ =>
            {
                Model.SetGameState(EGameState.Exit);
                Debug.LogWarning("cli exit");
            }).AddTo(Disposables);
            
            BackButtonClicked.Subscribe(_ =>
            {
                Model.SetSubState(EMenuSubState.Main);
                Debug.LogWarning("cli back");
            }).AddTo(Disposables);
        }
    }
}
