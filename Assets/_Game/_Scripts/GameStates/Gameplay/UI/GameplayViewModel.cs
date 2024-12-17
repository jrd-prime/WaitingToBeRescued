using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Data.SO.State;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.Tickers.DayTimer;
using _Game._Scripts.Framework.Tickers.Energy;
using _Game._Scripts.Framework.Tickers.Temperature;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public class GameplayViewModel : UIViewModelBase<IGameplayModel, EGameplaySubState>, IGameplayViewModel
    {
        #region Click

        public Subject<Unit> MenuBtnClicked { get; } = new();
        public Subject<Unit> CloseBtnClicked { get; } = new();
        public Subject<Unit> AddEnergyBtnClicked { get; } = new();

        #endregion

        public ReadOnlyReactiveProperty<EnergyData> ShelterEnergyData => Model.EnergyData;
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTemperatureData => Model.AmbientTempData;
        public ReadOnlyReactiveProperty<bool> IsGameRunning => Model.IsGameRunning;
        public ReactiveProperty<PreparedDayTimerData> PreparedDayTimerData { get; } = new();
        public ReactiveProperty<PreparedEnergyData> PreparedEnergyData { get; } = new();
        public ReactiveProperty<PreparedTemperatureData> PreparedTemperatureData { get; } = new();

        private DayCountdownUpdater _dayCountdownUpdater;
        private EnergyUpdater _energyUpdater;
        private TemperatureUpdater _temperatureUpdater;

        public override void Initialize()
        {
            _dayCountdownUpdater = new DayCountdownUpdater();
            _energyUpdater = new EnergyUpdater();
            _temperatureUpdater = new TemperatureUpdater();

            Model.CountdownData.Subscribe(UpdateDayTimerData).AddTo(Disposables);
            Model.EnergyData.Subscribe(UpdateEnergyData).AddTo(Disposables);
            Model.AmbientTempData.Subscribe(UpdateTemperatureData).AddTo(Disposables);

            // Buttons
            MenuBtnClicked.Subscribe(_ => Model.SetGameState(new StateData(EGameState.Menu))).AddTo(Disposables);
            CloseBtnClicked.Subscribe(_ => Model.SetPreviousState()).AddTo(Disposables);
            AddEnergyBtnClicked.Subscribe(_ => Model.AddEnergy()).AddTo(Disposables);
        }

        private void UpdateDayTimerData(DayTimerData data)
        {
            PreparedDayTimerData.Value = _dayCountdownUpdater.Update(data);
            PreparedDayTimerData.NotifyIfDataIsClass();
        }

        private void UpdateEnergyData(EnergyData data)
        {
            PreparedEnergyData.Value = _energyUpdater.Update(data);
            PreparedEnergyData.NotifyIfDataIsClass();
        }

        private void UpdateTemperatureData(AmbientTempData data)
        {
            PreparedTemperatureData.Value = _temperatureUpdater.Update(data);
            PreparedTemperatureData.NotifyIfDataIsClass();
        }

        #region Move

        public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);

        #endregion
    }

}
