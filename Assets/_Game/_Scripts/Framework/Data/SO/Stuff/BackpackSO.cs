using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Stuff
{
    [CreateAssetMenu(
        fileName = "backpack_settings",
        menuName = SOPathConst.ConfigPath + "backpack_settings",
        order = 100)]
    public class BackpackSO : SettingsSO
    {
        public float baseDailyTemperatureDrop = 1f;
        public int startDay = 0;
    }
}
