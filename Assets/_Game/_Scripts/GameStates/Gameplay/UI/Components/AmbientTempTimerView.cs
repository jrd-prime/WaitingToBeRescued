using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.Tickers.Temperature;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class AmbientTempTimerView : SubViewComponentBase<IGameplayViewModel>
    {
        private Label _currentTempLabel;
        private Label _nextDropLabel;

        public AmbientTempTimerView(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _currentTempLabel = Root.Q<Label>("cur-label").CheckOnNull();
            _nextDropLabel = Root.Q<Label>("next-down-label").CheckOnNull();
        }

        protected override void Init()
        {
            ViewModel.PreparedTemperatureData
                .Subscribe(UpdateTemperatureData)
                .AddTo(Disposables);
        }

        private void UpdateTemperatureData(PreparedTemperatureData data)
        {
            _currentTempLabel.text = data.Current;
            _nextDropLabel.text = data.NextChange;
        }
    }
}
