using System;
using _Game._Scripts.Framework.Data;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using _Game._Scripts.Framework.Manager.Game;
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
        private float _currentEnergyMax;
        private string _currentRemainingTime;
        private float _currentDayDuration;
        private int _currentDay;
        public Subject<Unit> MenuBtnClicked { get; } = new();
        public Subject<Unit> CloseBtnClicked { get; } = new();
        public Subject<Unit> AddEnergyBtnClicked { get; } = new();
        public ReadOnlyReactiveProperty<ShelterEnergyData> ShelterEnergyData => Model.EnergyData;
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTemperatureData => Model.AmbientTemperature;
        public ReadOnlyReactiveProperty<bool> IsGameRunning => Model.IsGameRunning;

        public ReactiveProperty<int> Day { get; } = new();
        public ReactiveProperty<float> DayDuration { get; } = new();
        public ReactiveProperty<string> RemainingTime { get; } = new();
        public ReactiveProperty<float> DayBarWidthPercent { get; } = new();
        public ReactiveProperty<float> EnergyBarWidthPercent { get; } = new();
        public ReactiveProperty<float> EnergyMax { get; } = new();

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

            Model.DayCountdownData
                .Subscribe(OnGameTimerUpdate)
                .AddTo(Disposables);

            Model.EnergyData
                .Subscribe(OnShelterEnergyUpdate)
                .AddTo(Disposables);
        }

        private void OnShelterEnergyUpdate(ShelterEnergyData shelterEnergyData)
        {
            var current = shelterEnergyData.Current;
            var max = shelterEnergyData.Max;


            Debug.LogWarning("On shelter energy update");
            if (Math.Abs(_currentEnergyMax - max) > JMathConst.Epsilon)
            {
                _currentEnergyMax = max;
                EnergyMax.Value = max;
            }

            EnergyBarWidthPercent.Value = current / max;

            Debug.LogWarning("energy percent = " + (current / max));
        }

        private void OnGameTimerUpdate(DayTimerData gameTimerData)
        {
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


            var minutes = Mathf.FloorToInt(remainingTime / 60);
            var seconds = Mathf.FloorToInt(remainingTime % 60);

            var formatted = $"{minutes:D2}:{seconds:D2}";
            if (_currentRemainingTime != formatted)
            {
                _currentRemainingTime = formatted;
                RemainingTime.Value = formatted;
            }
        }


        public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);
    }
}
