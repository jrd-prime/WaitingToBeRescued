using System;
using _Game._Scripts.Framework.Data;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.Framework.Manager.Shelter.Timer;
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

            Model.GameTimeData
                .Subscribe(OnGameTimerUpdate)
                .AddTo(Disposables);

            Model.EnergyData
                .Subscribe(OnShelterEnergyUpdate)
                .AddTo(Disposables);
        }

        private void OnShelterEnergyUpdate(ShelterEnergyData shelterEnergyData)
        {
            Debug.LogWarning("On shelter energy update");
            if (Math.Abs(EnergyMax.CurrentValue - shelterEnergyData.Max) > JMathConst.Epsilon)
                EnergyMax.Value = shelterEnergyData.Max;

            EnergyBarWidthPercent.Value = shelterEnergyData.Current / shelterEnergyData.Max;

            Debug.LogWarning("energy percent = " + (shelterEnergyData.Current / shelterEnergyData.Max));


            Debug.LogWarning(shelterEnergyData.Current / shelterEnergyData.Max);
        }

        private void OnGameTimerUpdate(GameTimerData gameTimerData)
        {
            if (Day.CurrentValue != gameTimerData.Day) Day.Value = gameTimerData.Day;

            if (Math.Abs(DayDuration.CurrentValue - gameTimerData.DayDuration) > JMathConst.Epsilon)
                DayDuration.Value = gameTimerData.DayDuration;

            DayBarWidthPercent.Value = gameTimerData.RemainingTime / gameTimerData.DayDuration;


            var minutes = Mathf.FloorToInt(gameTimerData.RemainingTime / 60);
            var seconds = Mathf.FloorToInt(gameTimerData.RemainingTime % 60);
            RemainingTime.Value = $"{minutes:D2}:{seconds:D2}";
        }


        public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);
    }
}
