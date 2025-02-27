﻿using System;
using _Game._Scripts.Framework.Tickers.DayTimer;
using _Game._Scripts.Framework.Tickers.Energy;
using _Game._Scripts.Framework.Tickers.Temperature;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Tickers
{
    public sealed class GameCountdownsController : IGameCountdownsController, IInitializable, IDisposable
    {
        public ReadOnlyReactiveProperty<bool> IsDayTimerDataModelLoaded => _dayTimerDataModel.IsModelLoaded;
        public ReactiveProperty<float> DayDuration { get; } = new();

        private int _currentDay;
        private DayTimerDataModel _dayTimerDataModel;
        private AmbientTempDataModel _ambientTempDataModel;
        private EnergyDataModel _energyDataModel;
        private readonly CompositeDisposable _disposables = new();

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _dayTimerDataModel = resolver.Resolve<DayTimerDataModel>();
            _ambientTempDataModel = resolver.Resolve<AmbientTempDataModel>();
            _energyDataModel = resolver.Resolve<EnergyDataModel>();
        }

        public void Initialize()
        {
            if (_energyDataModel == null) throw new NullReferenceException("EnergyDataModel is null");
            if (_dayTimerDataModel == null) throw new NullReferenceException("DayTimerDataModel is null");
            if (_ambientTempDataModel == null) throw new NullReferenceException("AmbientTempDataModel is null");

            _dayTimerDataModel.ModelData
                .Subscribe(OnDayTimerDataChanged)
                .AddTo(_disposables);
        }

        public float GetDayRemainingTime() => _dayTimerDataModel.GetRemainingTime();

        public void SetDayRemainingTime(float value) => _dayTimerDataModel.SetRemainingTime(value);


        private void OnDayTimerDataChanged(DayTimerSavableData timerSavableData)
        {
            if (!Mathf.Approximately(DayDuration.CurrentValue, timerSavableData.DayDuration))
                DayDuration.Value = timerSavableData.DayDuration;

            OnRemainingTimeUpdate(timerSavableData.RemainingTime);
        }

        private void OnNewDay()
        {
            _ambientTempDataModel.OnNewDay();
            _energyDataModel.OnNewDay();
        }

        private void OnRemainingTimeUpdate(float remainingTime)
        {
            _energyDataModel.OnTimerTick(remainingTime);
        }

        public void AddDay()
        {
            _dayTimerDataModel.AddDay();
            OnNewDay();
        }


        public void Dispose() => _disposables?.Dispose();
    }

    public interface IGameCountdownsController
    {
        public float GetDayRemainingTime();
        public void SetDayRemainingTime(float value);
        public ReadOnlyReactiveProperty<bool> IsDayTimerDataModelLoaded { get; }
        public ReactiveProperty<float> DayDuration { get; }
        public void AddDay();
    }
}
