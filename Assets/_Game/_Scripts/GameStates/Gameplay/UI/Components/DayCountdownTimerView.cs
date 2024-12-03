using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter;
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
    public sealed class DayCountdownTimerView : SubViewComponentBase<IGameplayViewModel>
    {
        private Label _countDown;
        private Label _day;
        private VisualElement _dayBar;

        private bool _isDayBarWidthSet;
        private const float AnimationDuration = 0.5f;
        private TweenerCore<float, float, FloatOptions> _dayBarTween;

        public DayCountdownTimerView(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _countDown = Root.Q<Label>("countdown-label").CheckOnNull();
            _day = Root.Q<Label>("day-label").CheckOnNull();
            _dayBar = Root.Q<VisualElement>("day-countdown-slider").CheckOnNull();
        }

        protected override void Init()
        {
            ViewModel.RemainingTimeFormatted.Subscribe(x => _countDown.text = x).AddTo(Disposables);
            ViewModel.Day.Subscribe(x => _day.text = x.ToString()).AddTo(Disposables);
            ViewModel.DayBarWidthPercent.Subscribe(UpdateEnergyBar).AddTo(Disposables);

            _dayBar.RegisterCallback<GeometryChangedEvent>(_ => InitDayCountdownBar(_dayBar.resolvedStyle.width));
        }


        private void InitDayCountdownBar(float width)
        {
            if (_isDayBarWidthSet) return;
            Debug.LogWarning("Init day bar width of bar");
            _dayBar.UnregisterCallback<GeometryChangedEvent>(_ => InitDayCountdownBar(_dayBar.resolvedStyle.width));
            _isDayBarWidthSet = true;
            _visualElementWidth = width;
            _currentWidth = width;
            UpdateEnergyBar(1);
        }

        private float _visualElementWidth;
        private float _animationDuration;
        private float _currentWidth;

        private void UpdateEnergyBar(float percent)
        {
            if (!_isDayBarWidthSet) return;

            var targetWidth = _visualElementWidth * percent;
            if (Mathf.Abs(targetWidth - _currentWidth) < JMathConst.Epsilon) return;
            _dayBarTween?.Kill();
            _dayBarTween = DOTween.To(() => _currentWidth, SetBarWidth, targetWidth, AnimationDuration);
        }

        private void SetBarWidth(float width)
        {
            _currentWidth = width;
            _dayBar.style.width = width;
        }
    }
}
