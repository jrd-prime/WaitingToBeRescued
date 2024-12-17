using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.MovementControl;
using _Game._Scripts.Framework.Tickers.DayTimer;
using _Game._Scripts.Framework.Tickers.Energy;
using _Game._Scripts.Framework.Tickers.Temperature;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public interface IGameplayModel : IUIModel<EGameplaySubState>
    {
        public ReadOnlyReactiveProperty<EnergyData> EnergyData { get; }
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTempData { get; }
        public ReadOnlyReactiveProperty<bool> IsGameRunning { get; }
        public ReadOnlyReactiveProperty<DayTimerData> CountdownData { get; }
        public void OnDownEvent(PointerDownEvent evt);
        public void OnMoveEvent(PointerMoveEvent evt);
        public void OnUpEvent(PointerUpEvent _);
        public void OnOutEvent(PointerOutEvent _);
        public void AddEnergy();
    }

    public class GameplayModel : CustomUIModelBase<EGameplaySubState>, IGameplayModel
    {
        public ReadOnlyReactiveProperty<bool> IsGameRunning => GameManager.IsGameRunning;
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTempData => _ambientTempDataModel.ModelData;
        public ReadOnlyReactiveProperty<DayTimerData> CountdownData => _dayTimerDataModel.ModelData;
        public ReadOnlyReactiveProperty<EnergyData> EnergyData => _energyDataModel.ModelData;

        public void AddEnergy() => _energyDataModel.IncreaseEnergy(30);


        private IMovementControlModel _movementModel;
        private EnergyDataModel _energyDataModel;
        private AmbientTempDataModel _ambientTempDataModel;
        private DayTimerDataModel _dayTimerDataModel;

        public override void Initialize()
        {
            _movementModel = ResolverHelp.ResolveAndCheck<IMovementControlModel>(Resolver);
            _energyDataModel = ResolverHelp.ResolveAndCheck<EnergyDataModel>(Resolver);
            _ambientTempDataModel = ResolverHelp.ResolveAndCheck<AmbientTempDataModel>(Resolver);
            _dayTimerDataModel = ResolverHelp.ResolveAndCheck<DayTimerDataModel>(Resolver);
        }


        public void OnDownEvent(PointerDownEvent evt) => _movementModel.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => _movementModel.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent _) => _movementModel.OnUpEvent(_);
        public void OnOutEvent(PointerOutEvent _) => _movementModel.OnOutEvent(_);
    }
}
