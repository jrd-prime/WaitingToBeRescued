using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Game
{
    [CreateAssetMenu(
        fileName = "movement-control-settings",
        menuName = SOPathConst.ConfigPath + "movement-control-settings",
        order = 100)]
    public class MovementControlSettings : SettingsSO
    {
        public float offsetForFullSpeed = 100;
    }
}
