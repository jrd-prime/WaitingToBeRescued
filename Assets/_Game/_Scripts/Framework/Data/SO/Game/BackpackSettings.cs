using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Game
{
    [CreateAssetMenu(
        fileName = "backpack_settings",
        menuName = SOPathConst.ConfigPath + "backpack_settings",
        order = 100)]
    public class BackpackSettings : SettingsSO
    {
        public float baseDailyTemperatureDrop = 1f;
        public int startDay = 0;
    }
}
