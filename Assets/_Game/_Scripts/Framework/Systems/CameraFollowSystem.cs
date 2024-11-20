using System;
using _Game._Scripts.Framework.Manager;
using _Game._Scripts.Framework.Manager.JCamera;
using VContainer;

namespace _Game._Scripts.Framework.Systems
{
    public class CameraFollowSystem
    {
        private ICameraManager _cameraManager;
        private bool _hasTarget;

        [Inject]
        private void Construct(ICameraManager cameraManager) => _cameraManager = cameraManager;

        public void SetTarget(ITrackableModel target)
        {
            if (_cameraManager == null) throw new NullReferenceException("CameraManager is null");

            // TODO remove this
            if (_hasTarget)
            {
                _cameraManager.RemoveTarget();
                _hasTarget = false;
            }
            else
            {
                if (target == null) throw new NullReferenceException("Target is null");
                _cameraManager.SetTarget(target);
                _hasTarget = true;
            }
        }
    }
}
