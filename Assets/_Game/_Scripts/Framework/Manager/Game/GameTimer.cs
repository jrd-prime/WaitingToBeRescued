using System;
using System.Collections;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Systems.SaveLoad;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.Game
{
    public struct GameTimerOptions
    {
        public float DayCycleTime;
        public float UpdateInterval;
        public float SaveInterval;
        public GameTimerModel TimerModel;
        public MonoBehaviour MonoBehaviour;
    }

    public sealed class GameTimer : IDisposable
    {
        private bool _isRunning;
        private Coroutine _timerCoroutine;
        private float _timeRemaining;
        private readonly float _dayCycleTime;
        private readonly float _updateInterval;
        private ISaveSystem _saveSystem;
        private readonly float _saveInterval;
        private float _saveTimer;
        private bool _cancel;
        private readonly GameTimerModel _timerModel;

        public GameTimer(GameTimerOptions options)
        {
            _dayCycleTime = options.DayCycleTime;
            _updateInterval = options.UpdateInterval;
            _timerModel = options.TimerModel;
            _saveInterval = options.SaveInterval;
            options.MonoBehaviour.StartCoroutine(GameTimerCoroutine());
        }

        [Inject]
        private void Construct(ISaveSystem saveSystem) => _saveSystem = saveSystem;

        public void SetGameRunningState(bool running)
        {
            if (_isRunning == running) return;
            _isRunning = running;
            if (_isRunning) StartGameTimer();
            else PauseGameTimer();
        }

        public void OnModelDataLoaded() => _timeRemaining = _timerModel.ModelData.CurrentValue.RemainingTime;

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
                        UpdateTimerData(_timerModel.GetDay(), _timeRemaining <= 0 ? _dayCycleTime : _timeRemaining);
                        elapsedTime = 0f;
                    }

                    if (_timeRemaining <= 0)
                    {
                        UpdateTimerData(_timerModel.GetDay() + 1, _timerModel.GetRemainingTime());
                        _timeRemaining = _dayCycleTime;
                    }

                    _saveTimer += deltaTime;
                    if (_saveTimer >= _saveInterval)
                    {
                        _saveSystem.SaveToFileAsync(_timerModel.GetModelData()).Forget();
                        _saveTimer = 0f;
                    }
                }

                yield return new WaitForFixedUpdate();
            }
        }

        private void UpdateTimerData(int day, float remainingTime) =>
            _timerModel.SetModelData(new GameTimerData(day, remainingTime));

        private void StartGameTimer() => _isRunning = true;
        private void PauseGameTimer() => _isRunning = false;

        public void Dispose()
        {
            _saveSystem?.Dispose();
        }
    }
}
