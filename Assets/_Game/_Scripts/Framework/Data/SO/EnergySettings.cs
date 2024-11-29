using _Game._Scripts.Framework.Data.Constants;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO
{
    [CreateAssetMenu(
        fileName = "energy-settings",
        menuName = SOPathConst.ConfigPath + "energy-settings",
        order = 100)]
    public class EnergySettings : SettingsSO
    {
        public override string Description => "Energy settings";

        [Header("Defaults")] [Range(100, 1000)]
        public float energyLimit = 100;

        [Range(1f, 10f)] [Tooltip("Default: maxEnergy * 3 per day")]
        public float dailyEnergyExpenditureMultiplier = 3f;
    }
}
