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
        private readonly float _updateInterval;
        private ISaveSystem _saveSystem;

        private const float SaveInterval = 1f;
        private float _saveTimer;
        private bool _cancel;
        private GameTimeModel _gameTimerModel;

        public GameTimer(float dayCycleTime, GameManagerBase gameManagerBase, float updateInterval = 0.1f)
        {
            _gameManagerBase = gameManagerBase;
            _dayCycleTime = dayCycleTime;
            _updateInterval = updateInterval;

            // _timeRemaining = _gameTimeDataRef.RemainingTime;
        }

        [Inject]
        private void Construct(ISaveSystem saveSystem, GameTimeModel gameTimeModel)
        {
            _saveSystem = saveSystem;
            _gameManagerBase.StartCoroutine(GameTimerCoroutine());
            _gameTimerModel = gameTimeModel;

            _timeRemaining = _gameTimerModel.ModelData.CurrentValue.RemainingTime;
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
            Debug.LogWarning("timer started / " + _timeRemaining);
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
                        var newData = new GameTimeDto
                        {
                            Day = _gameTimerModel.ModelData.CurrentValue.Day,
                            RemainingTime = _timeRemaining <= 0 ? _dayCycleTime : _timeRemaining
                        };

                        _gameTimerModel.SetNewModelData(newData);

                        elapsedTime = 0f;
                    }

                    if (_timeRemaining <= 0)
                    {
                        var newData = new GameTimeDto
                        {
                            Day = _gameTimerModel.ModelData.CurrentValue.Day + 1,
                            RemainingTime = _gameTimerModel.ModelData.CurrentValue.RemainingTime
                        };

                        _gameTimerModel.SetNewModelData(newData);

                        _timeRemaining = _dayCycleTime;
                    }

                    _saveTimer += deltaTime;
                    if (_saveTimer >= SaveInterval)
                    {
                        _saveSystem.Save(_gameTimerModel.ModelData.CurrentValue);
                        Debug.LogWarning(
                            $"Save data  {_gameTimerModel.ModelData.CurrentValue.Day} / {_gameTimerModel.ModelData.CurrentValue.RemainingTime}");

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
