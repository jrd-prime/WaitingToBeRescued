using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO
{
    [CreateAssetMenu(
        fileName = "gameplay-settings",
        menuName = SOPathConst.ConfigPath + "gameplay-settings",
        order = 100)]
    public class GameplaySettings : SettingsSO
    {
        public override string Description => "Gameplay Settings";

        // [Range(600, 3600)]
        public float gameDayInSeconds = 60;

        public float baseDailyTemperatureDrop = 1f;
        public int startDay = 0;
    }
}
