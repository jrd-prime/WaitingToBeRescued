using System;
using _Game._Scripts.Framework.Data;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.DayTimer;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public class GameplayViewModel : UIViewModelBase<IGameplayModel, EGameplaySubState>, IGameplayViewModel
    {
        public Subject<Unit> MenuBtnClicked { get; } = new();
        public Subject<Unit> CloseBtnClicked { get; } = new();
        public Subject<Unit> AddEnergyBtnClicked { get; } = new();
        public ReadOnlyReactiveProperty<EnergyData> ShelterEnergyData => Model.EnergyData;
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTemperatureData => Model.AmbientTempData;
        public ReadOnlyReactiveProperty<bool> IsGameRunning => Model.IsGameRunning;

        public ReactiveProperty<int> Day { get; } = new();
        public ReactiveProperty<float> DayDuration { get; } = new();
        public ReactiveProperty<string> RemainingTimeFormatted { get; } = new();
        public ReactiveProperty<string> EnergyValueFormatted { get; } = new();
        public ReactiveProperty<float> DayBarWidthPercent { get; } = new();
        public ReactiveProperty<float> EnergyBarWidthPercent { get; } = new();
        public ReactiveProperty<float> EnergyMax { get; } = new();

        private float _currentEnergyMax;
        private string _currentRemainingTime;
        private float _currentDayDuration;
        private int _currentDay;
        private float _energyUILastUpdateTime;
        private float _dayTimerUILastUpdateTime;

        public override void Initialize()
        {
            MenuBtnClicked
                .Subscribe(_ => Model.SetGameState(new StateData(EGameState.Menu)))
                .AddTo(Disposables);

            CloseBtnClicked
                .Subscribe(_ => Model.SetPreviousState())
                .AddTo(Disposables);

            AddEnergyBtnClicked
                .Subscribe(_ => Model.AddEnergy())
                .AddTo(Disposables);

            Model.CountdownData
                .Subscribe(OnGameTimerUpdated)
                .AddTo(Disposables);

            Model.EnergyData
                .Subscribe(OnEnergyDataUpdated)
                .AddTo(Disposables);
        }

        private void OnEnergyDataUpdated(EnergyData energyData)
        {
            var time = Time.time;

            if (time - _energyUILastUpdateTime <= 1f) return;

            _energyUILastUpdateTime = time;
            var current = energyData.Current;
            var max = energyData.Max;

            SetEnergyValueText(current, max);

            if (current <= 0)
            {
                _currentEnergyMax = max;
                EnergyMax.Value = max;
            }

            EnergyBarWidthPercent.Value = current / max;
        }

        private void SetEnergyValueText(float current, float max)
        {
            var formatted = $"{current:F1} / {max}";
            EnergyValueFormatted.Value = formatted;
        }

        private void OnGameTimerUpdated(DayTimerData gameTimerData)
        {
            var time = Time.time;
            if (time - _dayTimerUILastUpdateTime <= 1f) return;
            _dayTimerUILastUpdateTime = time;
            
            var day = gameTimerData.Day;
            var dayDuration = gameTimerData.DayDuration;
            var remainingTime = gameTimerData.RemainingTime;

            if (_currentDay != day)
            {
                _currentDay = day;
                Day.Value = day;
            }

            if (Math.Abs(_currentDayDuration - dayDuration) > JMathConst.Epsilon)
            {
                _currentDayDuration = dayDuration;
                DayDuration.Value = dayDuration;
            }

            DayBarWidthPercent.Value = remainingTime / dayDuration;

            SetDayTimeText(remainingTime);
        }

        private void SetDayTimeText(float value)
        {
            var minutes = Mathf.FloorToInt(value / 60);
            var seconds = Mathf.FloorToInt(value % 60);

            var formatted = $"{minutes:D2}:{seconds:D2}";
            if (_currentRemainingTime == formatted) return;
            _currentRemainingTime = formatted;
            RemainingTimeFormatted.Value = formatted;
        }


        public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);
    }
}
