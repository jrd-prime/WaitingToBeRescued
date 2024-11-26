using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.GameStates.Gameover;
using _Game._Scripts.GameStates.Gameplay;
using _Game._Scripts.GameStates.Gameplay.State;
using _Game._Scripts.GameStates.Menu;
using _Game._Scripts.GameStates.Menu.State;
using _Game._Scripts.GameStates.Pause;
using _Game._Scripts.GameStates.Win;
using _Game._Scripts.Player.Interfaces;
using R3;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.JrdStateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<EGameState, IGameState> _states = new();
        private IGameState _currentState = null;
        private IPlayerModel _playerModel;
        private GameManager _gameManager;
        private readonly CompositeDisposable _disposables = new();
        private bool isGameStarted;
        private ISettingsManager _settingsManager;
        private IStateMachineReactiveAdapter _ra;

        private EGameState _currentBaseState;
        private Enum _currentSubState;

        [Inject]
        private void Construct(IObjectResolver container)
        {
            _states.Add(EGameState.Menu, container.Resolve<MenuState>());
            _states.Add(EGameState.GameOver, container.Resolve<GameOverState>());
            _states.Add(EGameState.Pause, container.Resolve<PauseState>());
            _states.Add(EGameState.Gameplay, container.Resolve<GamePlayState>());
            _states.Add(EGameState.Win, container.Resolve<WinState>());

            _playerModel = container.Resolve<IPlayerModel>();
            _gameManager = container.Resolve<GameManager>();
            _ra = container.Resolve<IStateMachineReactiveAdapter>();
        }

        public void Start()
        {
            Debug.Log("State machine started! " + this);
            if (_currentState != null) return;

            var defStateData = new StateData { State = EGameState.Menu, SubState = default };

            // ChangeBaseState(EGameState.Menu, default);
            OnNewStateData(defStateData);

            _gameManager.IsGameStarted
                .Subscribe(value => isGameStarted = value)
                .AddTo(_disposables);
            _ra.StateData
                .Skip(1)
                .Subscribe(OnNewStateData)
                .AddTo(_disposables);
        }

        private void OnNewStateData(StateData stateData)
        {
            if (_currentBaseState != stateData.State)
            {
                ChangeBaseState(stateData.State, stateData.SubState);
                _currentBaseState = stateData.State;
            }
            else
            {
                if (!_states.TryGetValue(stateData.State, out var state))
                    throw new KeyNotFoundException($"State: {stateData.State} not found!");

                state.ChangeSubState(stateData.SubState);
                _currentSubState = stateData.SubState;
            }
        }

        public void ChangeBaseState(EGameState eGameState, Enum stateDataSubState)
        {
            if (!_states.TryGetValue(eGameState, out IGameState state))
                throw new KeyNotFoundException($"State: {eGameState} not found!");
            Debug.LogWarning(
                $"<color=darkblue>[STATE MACHINE]</color> Change TO: <b>{eGameState}</b> FROM {_currentState?.GetType().Name}");

            ChangeState(state);
            state.ChangeSubState(stateDataSubState);
        }

        private void ChangeState(IGameState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}
