using UnityEngine;

namespace _Game._Scripts.Framework.Helpers
{
    public class UpdateLimiter
    {
        private float _lastUpdateTime;

        public bool CanUpdate(float interval)
        {
            var time = Time.time;
            if (time - _lastUpdateTime <= interval) return false;

            _lastUpdateTime = time;
            return true;
        }
    }
}
