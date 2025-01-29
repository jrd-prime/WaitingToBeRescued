using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Main
{
    [CreateAssetMenu(
        fileName = "temperature-settings",
        menuName = SOPathConst.ConfigPath + "temperature-settings",
        order = 100)]
    public class TemperatureSettings : SettingsSO
    {
        public float startTempInCelsius = 33f;
        public float baseDailyTemperatureDrop = 1f;
    }
}
