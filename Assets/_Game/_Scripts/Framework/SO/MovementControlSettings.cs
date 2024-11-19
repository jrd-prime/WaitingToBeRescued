using _Game._Scripts.Framework.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.SO
{
    [CreateAssetMenu(
        fileName = "movement-control-settings",
        menuName = SOPathConst.ConfigPath + "movement-control-settings",
        order = 100)]
    public class MovementControlSettings : SettingsSO
    {
        public override string Description => "movement-control-settings";
        public float offsetForFullSpeed = 100;
    }
}
