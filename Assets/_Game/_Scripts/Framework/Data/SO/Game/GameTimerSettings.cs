using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Game
{
    [CreateAssetMenu(
        fileName = "game-time-settings",
        menuName = SOPathConst.ConfigPath + "game-time-settings",
        order = 100)]
    public class GameTimerSettings : SettingsSO
    {
        public int startDay = 0;
        public float gameDayInSeconds = 60;
    }
}
