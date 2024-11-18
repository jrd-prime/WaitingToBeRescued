using System;
using UnityEngine;

namespace _Game._Scripts.Framework.Managers.JCamera
{
    public interface ICameraManager
    {
        public void SetTarget(ITrackableModel target);
        public void RemoveTarget();
        public Camera GetMainCamera();
        public Vector3 GetCamEulerAngles();
        public Quaternion GetCamRotation();
    }
}
