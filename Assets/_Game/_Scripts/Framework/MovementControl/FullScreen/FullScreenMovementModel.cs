using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO.Game;
using _Game._Scripts.Framework.Manager.Settings;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.MovementControl.FullScreen
{
    public class FullScreenMovementModel : IFullScreenMovementModel, IInitializable, IDisposable
    {
        public ReactiveProperty<Vector3> MoveDirection { get; } = new(Vector3.zero);
        public ReactiveProperty<bool> IsTouchPositionVisible { get; } = new(false);
        public ReactiveProperty<Vector2> RingPosition { get; } = new(Vector2.zero);

        private bool _isTouchActive;
        private float _offsetForFullSpeed = 100f;
        private Vector3 _moveInput;
        private Vector3 _startTouchPosition;
        private ISettingsManager _settingsManager;

        [Inject]
        private void Construct(ISettingsManager settingsManager) => _settingsManager = settingsManager;

        public void Initialize()
        {
            if (_settingsManager == null) throw new NullReferenceException("SettingsManager is null.");

            var movementControlSettings = _settingsManager.GetConfig<MovementControlSettings>();
            _offsetForFullSpeed = movementControlSettings.offsetForFullSpeed;
        }

        private void SetMoveDirection(Vector3 value) => MoveDirection.Value = value;

        public void OnDownEvent(PointerDownEvent evt)
        {
            if (_isTouchActive) return;

            _isTouchActive = true;
            _startTouchPosition = evt.localPosition;
        }

        public void OnMoveEvent(PointerMoveEvent evt)
        {
            if (!_isTouchActive) return;

            var currentPosition = evt.localPosition;
            var offset = currentPosition - _startTouchPosition;
            var distance = offset.magnitude;

            if (distance > _offsetForFullSpeed) offset = offset.normalized * _offsetForFullSpeed;

            _moveInput = offset / _offsetForFullSpeed;
            _moveInput = Vector2.ClampMagnitude(_moveInput, 1.0f);

            SetMoveDirection(new Vector3(_moveInput.x, 0, _moveInput.y * -1f));
        }

        public void OnUpEvent(PointerUpEvent _) => ResetTouch();
        public void OnOutEvent(PointerOutEvent _) => ResetTouch();

        private void ResetTouch()
        {
            if (!_isTouchActive) return;

            _isTouchActive = false;
            _moveInput = Vector2.zero;

            SetMoveDirection(Vector3.zero);
        }

        public void Dispose()
        {
            MoveDirection?.Dispose();
            IsTouchPositionVisible?.Dispose();
            RingPosition?.Dispose();
        }
    }
}
