using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO
{
    [CreateAssetMenu(
        fileName = "game-time-settings",
        menuName = SOPathConst.ConfigPath + "game-time-settings",
        order = 100)]
    public class GameTimerSettings : SettingsSO
    {
        public override string Description => "Game Timer Settings";
        public int startDay = 0;
        public float gameDayInSeconds = 60;
    }
}
