using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class AmbientTemperatureTimer : SubViewComponentBase<IGameplayViewModel>
    {
        private VisualElement _movementRoot;
        private Label _currentTemp;
        private Label _nextDrop;
        private Label _countDown;
        private Label _day;

        public AmbientTemperatureTimer(IGameplayViewModel viewModel, in VisualElement root,
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
            ViewModel.AmbientTemperature.Subscribe(UpdateTemperatureData).AddTo(Disposables);
            ViewModel.GameTimeDto.Subscribe(x =>
            {
                int minutes = Mathf.FloorToInt(x.RemainingTime / 60); // Получаем количество минут
                int seconds =
                    Mathf.FloorToInt(x.RemainingTime % 60); // Получаем оставшиеся секунды (целые числа)

// Форматируем строку без десятичных
                string timeFormatted = string.Format("{0:D2}:{1:D2}", minutes, seconds);

                _countDown.text = timeFormatted;
                _day.text = x.Day.ToString();
            }).AddTo(Disposables);
        }

        private void UpdateTemperatureData(AmbientTempData ambientTemperatureData)
        {
            _currentTemp.text = ambientTemperatureData.Current.ToString();
            _nextDrop.text = ambientTemperatureData.NextChange.ToString();
        }
    }
}
