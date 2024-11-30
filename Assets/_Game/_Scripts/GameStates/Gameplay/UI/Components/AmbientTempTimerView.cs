using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class AmbientTempTimerView : SubViewComponentBase<IGameplayViewModel>
    {
        private VisualElement _movementRoot;
        private Label _currentTemp;
        private Label _nextDrop;
        private Label _countDown;
        private Label _day;

        public AmbientTempTimerView(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _currentTemp = Root.Q<Label>("cur-label").CheckOnNull();
            _nextDrop = Root.Q<Label>("next-down-label").CheckOnNull();
            _countDown = Root.Q<Label>("countdown-label").CheckOnNull();
            _day = Root.Q<Label>("day-label").CheckOnNull();
        }

        protected override void Init()
        {
            ViewModel.AmbientTemperatureData.Subscribe(UpdateTemperatureData).AddTo(Disposables);
            ViewModel.GameTimerData.Subscribe(x =>
            {
                var minutes = Mathf.FloorToInt(x.RemainingTime / 60);
                var seconds = Mathf.FloorToInt(x.RemainingTime % 60);

                string timeFormatted = $"{minutes:D2}:{seconds:D2}";

                _countDown.text = timeFormatted;
                _day.text = x.Day.ToString();
            }).AddTo(Disposables);
        }

        private void UpdateTemperatureData(AmbientTempData ambientTemperatureData)
        {
            var temp = ambientTemperatureData.Current;
            var curr = temp switch
            {
                > 0 => $"+{temp}",
                < 0 => $"{temp}",
                _ => $"{temp}"
            };

            _currentTemp.text = curr;
            _nextDrop.text = ambientTemperatureData.NextChange.ToString();
        }
    }
}
