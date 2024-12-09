using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Game
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
