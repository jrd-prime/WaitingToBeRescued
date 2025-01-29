using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Main
{
    [CreateAssetMenu(
        fileName = "gameplay-settings",
        menuName = SOPathConst.ConfigPath + "gameplay-settings",
        order = 100)]
    public class GameplaySettings : SettingsSO
    {
        public float baseDailyTemperatureDrop = 1f;
        public int startDay = 0;
    }
}
