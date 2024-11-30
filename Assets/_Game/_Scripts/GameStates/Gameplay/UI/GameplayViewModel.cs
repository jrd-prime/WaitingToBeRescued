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
        public ReadOnlyReactiveProperty<ShelterEnergyData> ShelterEnergyData => Model.ShelterEnergyData;
        public ReadOnlyReactiveProperty<AmbientTempData> AmbientTemperatureData => Model.AmbientTemperature;
        public ReadOnlyReactiveProperty<GameTimerData> GameTimerData  => Model.GameTimeDto;
        public ReadOnlyReactiveProperty<bool> IsGameRunning => Model.IsGameRunning;


        public override void Initialize()
        {
            MenuBtnClicked
                .Subscribe(
                    _ =>
                    {
                        Model.SetGameState(new StateData(EGameState.Menu));
                        Debug.LogWarning("menu button clicked");
                    }
                )
                .AddTo(Disposables);

            CloseBtnClicked
                .Subscribe(_ => Model.SetPreviousState())
                .AddTo(Disposables);
            
            AddEnergyBtnClicked.Subscribe(_ => Model.AddEnergy()).AddTo(Disposables);
        }

        public void OnDownEvent(PointerDownEvent evt) => Model.OnDownEvent(evt);
        public void OnMoveEvent(PointerMoveEvent evt) => Model.OnMoveEvent(evt);
        public void OnUpEvent(PointerUpEvent evt) => Model.OnUpEvent(evt);
        public void OnOutEvent(PointerOutEvent evt) => Model.OnOutEvent(evt);
    }
}
