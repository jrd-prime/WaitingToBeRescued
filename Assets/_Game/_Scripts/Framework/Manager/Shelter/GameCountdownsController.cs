using System;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.Framework.Manager.Shelter.Timer;
using R3;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    public class GameCountdownsController : IInitializable, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private int _currentDay;
        private GameTimerModel _timerModel;
        private AmbientTemperatureModel _ambientTemperatureModel;
        private ShelterEnergyModel _shelterEnergyModel;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _timerModel = resolver.Resolve<GameTimerModel>();
            _ambientTemperatureModel = resolver.Resolve<AmbientTemperatureModel>();
            _shelterEnergyModel = resolver.Resolve<ShelterEnergyModel>();
        }

        public void Initialize()
        {
            _timerModel.ModelData.Subscribe(OnTimerModelChanged).AddTo(_disposables);
        }

        private void OnTimerModelChanged(GameTimerData timerData)
        {
            if (_currentDay != timerData.Day)
            {
                _currentDay = timerData.Day;
                _ambientTemperatureModel.OnNewDay();
            }

            _shelterEnergyModel.OnTimeTicked(timerData.RemainingTime);
        }

        public void Dispose() => _disposables?.Dispose();
    }
}
