using UnityEngine;

namespace _Game._Scripts.Framework.Helpers.Extensions
{
    public static class ColliderExtension
    {
        public static bool IsRightLayer(this Collider other, LayerMask triggerLayer) =>
            ((1 << other.gameObject.layer) & triggerLayer) != 0;
    }
}
