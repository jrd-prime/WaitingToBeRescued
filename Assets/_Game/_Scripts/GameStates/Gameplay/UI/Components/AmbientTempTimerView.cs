using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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
        private VisualElement _dayBar;
        private bool _isFullEnergyBarWidthSet;
        private float _fullEnergyWidth;
        private float _pxPerPointEnergy;
        private float _currentEnergyBarWidth;
        private float _energyInitial;
        private TweenerCore<float, float, FloatOptions> _dayCountdownTween;

        private const float Epsilon = 0.001f;
        private const float AnimationDuration = 0.5f;

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
            _dayBar = Root.Q<VisualElement>("day-countdown-slider").CheckOnNull();
        }

        protected override void Init()
        {
            _dayBar.RegisterCallback<GeometryChangedEvent>(
                _ => InitDayCountdownBar(_dayBar.resolvedStyle.width));

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


        private void InitDayCountdownBar(float width)
        {
            if (_isFullEnergyBarWidthSet) return;
            _isFullEnergyBarWidthSet = true;
            _fullEnergyWidth = width;
            _pxPerPointEnergy = _fullEnergyWidth / _energyInitial;
            _currentEnergyBarWidth = _fullEnergyWidth;
            UpdateEnergyBar(_energyInitial);
        }

        private void UpdateEnergyBar(float value)
        {
            // _countDown.text = $"{value:F1} / {_energyInitial}";

            if (!_isFullEnergyBarWidthSet) return;

            var targetWidth = GetTargetWidth(value);

            if (Math.Abs(targetWidth - _currentEnergyBarWidth) < Epsilon) return;

            _dayCountdownTween.Kill();
            _dayCountdownTween = DOTween.To(GetBarWidth, SetBarWidth, targetWidth, AnimationDuration);
        }

        private float GetTargetWidth(float value) => _pxPerPointEnergy * value;
        private float GetBarWidth() => _currentEnergyBarWidth;

        private void SetBarWidth(float x)
        {
            _currentEnergyBarWidth = x;
            _dayBar.style.width = x;
        }


        private void UpdateShelterEnergy(ShelterEnergyData shelterEnergyData)
        {
            _energyInitial = shelterEnergyData.Max;
            UpdateEnergyBar(shelterEnergyData.Current);
        }
    }
}
