using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class ShelterEnergyTimerView : SubViewComponentBase<IGameplayViewModel>
    {
        private const float Epsilon = 0.001f;
        private const float AnimationDuration = 0.5f;
        private VisualElement _energyBar;
        private Label _energyLabel;
        private bool _isFullEnergyBarWidthSet;
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
            _energyBar = Root.Q<VisualElement>("timer-slider").CheckOnNull();
            _energyLabel = Root.Q<Label>("timer-label").CheckOnNull();
            _energyBar.RegisterCallback<GeometryChangedEvent>(
                _ => InitEnergyBar(_energyBar.resolvedStyle.width));
        }

        private void InitEnergyBar(float width)
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
            _energyLabel.text = $"{value:F1} / {_energyInitial}";

            if (!_isFullEnergyBarWidthSet) return;

            var targetWidth = GetTargetWidth(value);

            if (Math.Abs(targetWidth - _currentEnergyBarWidth) < Epsilon) return;

            _healthTween.Kill();
            _healthTween = DOTween.To(GetBarWidth, SetBarWidth, targetWidth, AnimationDuration);
        }

        private float GetTargetWidth(float value) => _pxPerPointEnergy * value;
        private float GetBarWidth() => _currentEnergyBarWidth;

        private void SetBarWidth(float x)
        {
            _currentEnergyBarWidth = x;
            _energyBar.style.width = x;
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
