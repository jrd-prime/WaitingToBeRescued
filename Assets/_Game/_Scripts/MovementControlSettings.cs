using _Game._Scripts.Framework.Constants;
using _Game._Scripts.Framework.SO;
using UnityEngine;

namespace _Game._Scripts
{
    [CreateAssetMenu(
        fileName = "MovementControlSettings",
        menuName = SOPathConst.ConfigPath + "Movement Control Settings",
        order = 100)]
    public class MovementControlSettings : SettingsSO
    {
        public override string Description => "Movement Control Settings";
        public float offsetForFullSpeed = 100;
    }
}
