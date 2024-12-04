using UnityEngine;

namespace _Game._Scripts.Framework.Helpers
{
    public static class JMath
    {
        public static int ToMinutes(this float value) => Mathf.FloorToInt(value / 60);
        public static int ToSeconds(this float value) => Mathf.FloorToInt(value % 60);
    }
}
