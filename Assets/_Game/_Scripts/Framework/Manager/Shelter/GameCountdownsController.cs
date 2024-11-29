using System;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
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

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _timerModel = resolver.Resolve<GameTimerModel>();
            _ambientTemperatureModel = resolver.Resolve<AmbientTemperatureModel>();
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
        }

        public void Dispose() => _disposables?.Dispose();
    }
}
