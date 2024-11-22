using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.GameStateMachine.State.Gameover;
using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.Framework.GameStateMachine.State.Pause;
using _Game._Scripts.Framework.GameStateMachine.State.Win;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UIOLD;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.GameStateMachine
{
    public interface IStateMachine : IPostStartable, IDisposable
    {
        public void ChangeStateTo(GameStateType gameStateType);
    }

    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<GameStateType, IGameState> _states = new();
        private IGameState _currentState = null;
        private IPlayerModel _playerModel;
        private GameManager _gameManager;
        private readonly CompositeDisposable _disposables = new();
        private bool isGameStarted;

        [Inject]
        private void Construct(IObjectResolver container)
        {
            _states.Add(GameStateType.Menu, container.Resolve<MenuState>());
            _states.Add(GameStateType.GameOver, container.Resolve<GameOverState>());
            _states.Add(GameStateType.Pause, container.Resolve<PauseState>());
            _states.Add(GameStateType.Gameplay, container.Resolve<GamePlayState>());
            _states.Add(GameStateType.Win, container.Resolve<WinState>());

            _playerModel = container.Resolve<IPlayerModel>();
            _gameManager = container.Resolve<GameManager>();
        }

        public void PostStart()
        {
            if (_currentState != null) return;

            ChangeStateTo(GameStateType.Menu);

            _gameManager.IsGameStarted
                .Subscribe(value => isGameStarted = value).AddTo(_disposables);

            // _playerModel.Health
            //     .Where(h => h <= 0)
            //     .Subscribe(h =>
            //     {
            //         if (isGameStarted) ChangeStateTo(StateType.GameOver);
            //     })
            //     .AddTo(_disposables);
        }

        public void ChangeStateTo(GameStateType gameStateType)
        {
            if (!_states.TryGetValue(gameStateType, out IGameState state))
                throw new KeyNotFoundException($"State: {gameStateType} not found!");
            Debug.LogWarning(
                $"<color=yellow>[STATE MACHINE]</color> <color=cyan>Change state to: <b>{gameStateType}</b></color> / Current state: {_currentState?.GetType().Name}");

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
    }
}
