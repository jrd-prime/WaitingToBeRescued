using System;
using _Game._Scripts.Framework.Helpers.Attributes;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Managers.JCamera
{
    public abstract class CameraManagerBase : MonoBehaviour, ICameraManager
    {
        public abstract void SetTarget(ITrackableModel target);

        public abstract void RemoveTarget();

        public abstract Camera GetMainCamera();

        public abstract Vector3 GetCamEulerAngles();

        public abstract Quaternion GetCamRotation();
    }

    public class CameraManager : CameraManagerBase, IInitializable
    {
        [SerializeField] private Vector3 cameraOffset = new(0, 10, -5);
        [RequiredField, SerializeField] private Camera mainCamera;

        private ITrackableModel _targetModel;
        private readonly CompositeDisposable _disposables = new();

        public void Initialize()
        {
            if (mainCamera == null) throw new NullReferenceException($"MainCamera is null. {this}");
            SetCameraPosition(cameraOffset);
        }

        private void SetCameraPosition(Vector3 newPosition)
        {
            if (mainCamera.transform.position == newPosition) return;
            mainCamera.transform.position = newPosition + cameraOffset;
        }

        public override void SetTarget(ITrackableModel target)
        {
            if (target == null) throw new ArgumentNullException($"Target is null. {this}");

            SetCameraPosition(target.Position.CurrentValue);

            if (_targetModel != null) _disposables?.Dispose();
            SubscribeToTargetPosition(target);
        }

        public override void RemoveTarget()
        {
            _targetModel = null;
            _disposables?.Dispose();
        }

        public override Camera GetMainCamera() => mainCamera;
        public override Vector3 GetCamEulerAngles() => mainCamera.transform.eulerAngles;
        public override Quaternion GetCamRotation() => mainCamera.transform.rotation;

        private void SubscribeToTargetPosition(ITrackableModel target)
        {
            _targetModel = target;
            _targetModel.Position
                .Subscribe(SetCameraPosition)
                .AddTo(_disposables);
        }
    }
}
