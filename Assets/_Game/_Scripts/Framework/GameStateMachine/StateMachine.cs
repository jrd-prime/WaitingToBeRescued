using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.GameStates.Gameover;
using _Game._Scripts.GameStates.Gameplay;
using _Game._Scripts.GameStates.Menu;
using _Game._Scripts.GameStates.Pause;
using _Game._Scripts.GameStates.Win;
using _Game._Scripts.Player.Interfaces;
using R3;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.GameStateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<EGameState, IGameState> _states = new();
        private IGameState _currentState = null;
        private IPlayerModel _playerModel;
        private GameManager _gameManager;
        private readonly CompositeDisposable _disposables = new();
        private bool isGameStarted;
        public Action<EGameState> ChangeStateCallback;
        private ISettingsManager _settingsManager;

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
        }

        public void PostStart()
        {
        }

        public void ChangeStateTo(EGameState eGameState)
        {
            if (!_states.TryGetValue(eGameState, out IGameState state))
                throw new KeyNotFoundException($"State: {eGameState} not found!");
            Debug.LogWarning(
                $"<color=yellow>[STATE MACHINE]</color> <color=cyan>Change state to: <b>{eGameState}</b></color> / Current state: {_currentState?.GetType().Name}");

            state.SetCallback(ChangeStateCallback);

            ChangeState(state);
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

        public void Start()
        {
            ChangeStateCallback += ChangeStateTo;
            Debug.LogWarning("start " + this);
            if (_currentState != null) return;

            ChangeStateTo(EGameState.Menu);

            _gameManager.IsGameStarted
                .Subscribe(value => isGameStarted = value)
                .AddTo(_disposables);
        }
    }
}
