using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
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
    public sealed class ShelterEnergyTimerView : SubViewComponentBase<IGameplayViewModel>
    {
        private const float Epsilon = 0.001f;
        private const float AnimationDuration = 0.5f;
        private VisualElement _timerSlider;
        private Label _timerLabel;
        private bool isFullEnergyBarWidthSet;
        private float _fullEnergyWidth;
        private float _pxPerPointEnergy;
        private float _currentEnergyBarWidth;
        private float _energyInitial;

        private TweenerCore<float, float, FloatOptions> _healthTween;

        public ShelterEnergyTimerView(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _timerSlider = Root.Q<VisualElement>("timer-slider").CheckOnNull();
            _timerLabel = Root.Q<Label>("timer-label").CheckOnNull();
            _timerSlider.RegisterCallback<GeometryChangedEvent>(
                _ => SetEnergyBarWidth(_timerSlider.resolvedStyle.width));
        }

        private void SetEnergyBarWidth(float width)
        {
            if (isFullEnergyBarWidthSet) return;
            isFullEnergyBarWidthSet = true;
            _fullEnergyWidth = width;
            _pxPerPointEnergy = _fullEnergyWidth / _energyInitial;
            _currentEnergyBarWidth = _fullEnergyWidth;
            UpdateEnergyBar(_energyInitial);
        }

        private void UpdateEnergyBar(float health)
        {
            var energy = $"{health:F1}";
            _timerLabel.text = $"{energy} / {_energyInitial}";

            if (!isFullEnergyBarWidthSet) return;

            var targetWidth = _pxPerPointEnergy * health;

            if (Math.Abs(targetWidth - _currentEnergyBarWidth) < Epsilon) return;

            _healthTween.Kill();
            _healthTween = DOTween.To(
                () => _currentEnergyBarWidth,
                x =>
                {
                    _currentEnergyBarWidth = x;
                    _timerSlider.style.width = x;
                },
                targetWidth,
                AnimationDuration
            );
        }

        protected override void Init()
        {
            ViewModel.ShelterEnergyData.Subscribe(UpdateShelterEnergy).AddTo(Disposables);
        }

        private void UpdateShelterEnergy(ShelterEnergyData shelterEnergyData)
        {
            _energyInitial = shelterEnergyData.Max;
            UpdateEnergyBar(shelterEnergyData.Current);
        }
    }
}
