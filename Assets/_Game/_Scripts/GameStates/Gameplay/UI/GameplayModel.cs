using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.DayTimer;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.Framework.MovementControl;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public interface IGameplayModel : IUIModel<EGameplaySubState>
    {
        public void OnDownEvent(PointerDownEvent evt);
        public void OnMoveEvent(PointerMoveEvent evt);
        public void OnUpEvent(PointerUpEvent _);
        public void OnOutEvent(PointerOutEvent _);
        public ReactiveProperty<ShelterEnergyData> EnergyData { get; }
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTemperature { get; }
        public ReadOnlyReactiveProperty<bool> IsGameRunning { get; }
        public ReactiveProperty<DayTimerData> DayCountdownData { get; }
        public void AddEnergy();
    }

    public class GameplayModel : CustomUIModelBase<EGameplaySubState>, IGameplayModel
    {
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTemperature => _ambientTempDataModel.ModelData;
        public ReadOnlyReactiveProperty<bool> IsGameRunning => GameManager.IsGameRunning;
        public ReactiveProperty<DayTimerData> DayCountdownData { get; } = new();
        public ReactiveProperty<ShelterEnergyData> EnergyData { get; } = new();
        public void AddEnergy() => _energyDataModel.AddEnergy(30);


        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTempData => _ambientTempDataModel.ModelData;

        private IMovementControlModel _movementModel;
        private EnergyDataModel _energyDataModel;
        private AmbientTemperatureDataModel _ambientTempDataModel;
        private DayTimerDataModel _dayTimerDataModel;

        public override void Initialize()
        {
            _movementModel = ResolverHelp.ResolveAndCheck<IMovementControlModel>(Resolver);
            _energyDataModel = ResolverHelp.ResolveAndCheck<EnergyDataModel>(Resolver);
            _ambientTempDataModel = ResolverHelp.ResolveAndCheck<AmbientTemperatureDataModel>(Resolver);
            _dayTimerDataModel = ResolverHelp.ResolveAndCheck<DayTimerDataModel>(Resolver);

            _dayTimerDataModel.ModelData
                .Subscribe(x =>
                {
                    DayCountdownData.Value = x;
                })
                .AddTo(Disposables);

            _energyDataModel.ModelData
                .Subscribe(x => EnergyData.Value = x)
                .AddTo(Disposables);
        }


        public void OnDownEvent(PointerDownEvent evt) => _movementModel.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => _movementModel.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent _) => _movementModel.OnUpEvent(_);
        public void OnOutEvent(PointerOutEvent _) => _movementModel.OnOutEvent(_);
    }
}
