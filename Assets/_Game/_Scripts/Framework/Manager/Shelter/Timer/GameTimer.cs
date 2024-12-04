using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter.Timer
{
    public struct GameTimerOptions
    {
        public float DayDuration;
        public float UpdateInterval;
        public IGameCountdownsController CountdownsController;
        public MonoBehaviour MonoBehaviour;
    }

    public sealed class GameTimer : IDisposable
    {
        private readonly float _updateInterval;

        private float _dayDuration;
        private bool _isRunning;
        private float _timeRemaining;
        private bool _cancel;

        private Coroutine _timerCoroutine;
        private readonly IGameCountdownsController _countdownsController;

        private readonly CompositeDisposable _disposables = new();

        public GameTimer(GameTimerOptions options)
        {
            _dayDuration = options.DayDuration;
            _updateInterval = options.UpdateInterval;
            _countdownsController = options.CountdownsController;
            // options.MonoBehaviour.StartCoroutine(GameTimerCoroutine());
            Debug.Log("Game timer started. Day cycle time: " + _dayDuration);

            _countdownsController.DayDuration.Subscribe(x =>
            {
                Debug.LogWarning("Day duration changed: " + x);
                _dayDuration = x;
            }).AddTo(_disposables);

            tt();
        }

        public void SetGameRunningState(bool running)
        {
            if (_isRunning == running) return;
            _isRunning = running;
            if (_isRunning) StartGameTimer();
            else PauseGameTimer();
        }

        public void OnModelDataLoaded()
        {
            Debug.LogWarning("timer time remaining: " + _timeRemaining);
            _timeRemaining = _countdownsController.GetDayRemainingTime();
        }

        private async void tt()
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
                        _countdownsController.SetDayRemainingTime(_timeRemaining <= 0 ? _dayDuration : _timeRemaining);
                        elapsedTime = 0f;
                    }

                    if (_timeRemaining <= 0)
                    {
                        _countdownsController.AddDay();
                        _timeRemaining = _dayDuration;
                    }
                }

                await UniTask.WaitForFixedUpdate();
            }
        }

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
                        _countdownsController.SetDayRemainingTime(_timeRemaining <= 0 ? _dayDuration : _timeRemaining);
                        elapsedTime = 0f;
                    }

                    if (_timeRemaining <= 0)
                    {
                        _countdownsController.AddDay();
                        _timeRemaining = _dayDuration;
                    }
                }

                yield return null;
            }
        }

        private void StartGameTimer() => _isRunning = true;
        private void PauseGameTimer() => _isRunning = false;

        public void Dispose() => _disposables?.Dispose();
    }
}
