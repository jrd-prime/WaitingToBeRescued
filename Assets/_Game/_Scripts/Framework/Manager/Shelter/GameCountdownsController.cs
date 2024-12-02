using System;
using _Game._Scripts.Framework.Manager.Shelter.DayTimer;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using R3;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    public class GameCountdownsController : IGameCountdownsController, IInitializable, IDisposable
    {
        public ReadOnlyReactiveProperty<bool> IsDayTimerDataModelLoaded => _dayTimerDataModel.IsModelLoaded;
        public ReactiveProperty<float> DayDuration { get; } = new();

        private int _currentDay;
        private DayTimerDataModel _dayTimerDataModel;
        private AmbientTemperatureDataModel _ambientTemperatureDataModel;
        private EnergyDataModel _energyDataModel;
        private readonly CompositeDisposable _disposables = new();

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _dayTimerDataModel = resolver.Resolve<DayTimerDataModel>();
            _ambientTemperatureDataModel = resolver.Resolve<AmbientTemperatureDataModel>();
            _energyDataModel = resolver.Resolve<EnergyDataModel>();
        }

        public void Initialize()
        {
            _dayTimerDataModel.ModelData
                .Subscribe(OnDayTimerDataChanged)
                .AddTo(_disposables);
        }

        private void OnDayTimerDataChanged(DayTimerData timerData)
        {
            DayDuration.Value = timerData.DayDuration;


            // if (_currentDay != timerData.Day)
            // {
            //     _currentDay = timerData.Day;
            //     _ambientTemperatureModel.OnNewDay();
            // }

            // _energyDataModel.OnTimerTick(timerData.RemainingTime);
        }

        public float GetDayRemainingTime() => _dayTimerDataModel.GetRemainingTime();

        public void SetDayRemainingTime(float value)
        {
            _dayTimerDataModel.SetRemainingTime(value);
            OnRemainingTimeUpdate();

            if (value <= 0) AddDay();
        }

        private void OnNewDay()
        {
        }

        private void OnRemainingTimeUpdate()
        {
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
    }
}
