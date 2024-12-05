﻿using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.Shelter;
using _Game._Scripts.Framework.Shelter.DayTimer;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
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
        private JTweenAnim _dayCountdownBarTween;
        private string _remainingTime;
        private int _dayNumber;
        private EventCallback<GeometryChangedEvent> _dayBarCallback;
        private float _visualElementWidth;
        private float _currentWidth;
        private TweenerCore<float, float, FloatOptions> _tween;

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
            Debug.LogWarning("init day bar");
        }


        protected override void Init()
        {
            _dayBarCallback = _ => InitDayCountdownBar(_dayBar.resolvedStyle.width);

            _dayBar.RegisterCallback(_dayBarCallback);

            ViewModel.PreparedDayTimerData.Subscribe(UpdateDayBar).AddTo(Disposables);
        }


        private void InitDayCountdownBar(float width)
        {
            if (_isDayBarWidthSet) return;
            Debug.LogWarning("Init day bar width of bar");
            _dayBar.UnregisterCallback(_dayBarCallback);
            _isDayBarWidthSet = true;
            _currentWidth = width;
            _visualElementWidth = width;

            _dayCountdownBarTween = new JTweenAnim(_dayBar, width, AnimationDuration);
            
            UpdateDayBar(ViewModel.PreparedDayTimerData.CurrentValue);
        }

        private void UpdateDayBar(PreparedDayTimerData data)
        {
            _countDown.text = data.RemainingTimeFormatted;
            _day.text = data.Day.ToString();
            if (!_isDayBarWidthSet) return;

            _dayCountdownBarTween.RunTween(data.DayBarWidthPercent);
        }
    }
}
