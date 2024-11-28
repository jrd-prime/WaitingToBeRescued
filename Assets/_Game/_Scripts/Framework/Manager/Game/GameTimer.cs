using System;
using System.Collections;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Systems.SaveLoad;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.Game
{
    public sealed class GameTimer : IDisposable
    {
        private bool _isRunning;
        private Coroutine _timerCoroutine;
        private float _timeRemaining;

        private readonly float _dayCycleTime;
        private readonly GameManagerBase _gameManagerBase;
        private readonly GameTimeDto _gameTimeDataRef;
        private readonly float _updateInterval;
        private ISaveSystem _saveSystem;

        private const float SaveInterval = 5f;
        private float _saveTimer;
        private bool _cancel;

        public GameTimer(float dayCycleTime, GameManagerBase gameManagerBase, ref GameTimeDto gameTimeData,
            float updateInterval = 0.1f)
        {
            _gameManagerBase = gameManagerBase;
            _gameTimeDataRef = gameTimeData;
            _dayCycleTime = dayCycleTime;
            _updateInterval = updateInterval;

            _timeRemaining = _gameTimeDataRef.RemainingDayTime;
        }

        [Inject]
        private void Construct(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
            _gameManagerBase.StartCoroutine(GameTimerCoroutine());
        }

        public void SetGameRunningState(bool running)
        {
            if (_isRunning == running) return;

            _isRunning = running;

            if (_isRunning) StartGameTimer();
            else PauseGameTimer();
        }

        private void StartGameTimer() => _isRunning = true;
        private void PauseGameTimer() => _isRunning = false;


        private IEnumerator GameTimerCoroutine()
        {
            var elapsedTime = 0f;

            while (!_cancel)
            {
                if (_isRunning)
                {
                    var deltaTime = Time.deltaTime;
                    _timeRemaining -= deltaTime;
                    elapsedTime += deltaTime;

                    if (elapsedTime >= _updateInterval)
                    {
                        _gameTimeDataRef.SetRemainingDayTime(_timeRemaining <= 0 ? _dayCycleTime : _timeRemaining);
                        elapsedTime = 0f;
                    }

                    if (_timeRemaining <= 0)
                    {
                        _gameTimeDataRef.SetDay(_gameTimeDataRef.Day + 1);
                        _timeRemaining = _dayCycleTime;
                    }

                    _gameManagerBase.UpdateGameTimeDto();
                    _saveTimer += deltaTime;
                    if (_saveTimer >= SaveInterval)
                    {
                        _saveSystem.Save(_gameTimeDataRef, ESaveLogic.Now);
                        _saveTimer = 0f;
                    }
                }

                yield return new WaitForFixedUpdate();
            }
        }

        public void Dispose()
        {
            _cancel = true;
            _saveSystem?.Dispose();
        }
    }
}
