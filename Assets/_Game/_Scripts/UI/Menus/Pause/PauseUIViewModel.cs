﻿using _Game._Scripts.UI.Base;
using R3;

namespace _Game._Scripts.UI.Pause
{
    public class PauseUIViewModel : UIViewModelCustom<IPauseUIModel>
    {
        public Subject<Unit> ContinueButtonClicked { get; } = new();
        public Subject<Unit> SettingsButtonClicked { get; } = new();
        public Subject<Unit> ToMainMenuButtonClicked { get; } = new();

        public override void Initialize()
        {
            ContinueButtonClicked.Subscribe(_ => Model.ContinueButtonClicked()).AddTo(Disposables);
            SettingsButtonClicked.Subscribe(_ => Model.SettingsButtonClicked()).AddTo(Disposables);
            ToMainMenuButtonClicked.Subscribe(_ => Model.ToMainMenuButtonClicked()).AddTo(Disposables);
        }
    }
}
