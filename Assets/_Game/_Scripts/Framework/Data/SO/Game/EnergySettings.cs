using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO._Base;
using UnityEngine;

namespace _Game._Scripts.Framework.Data.SO.Game
{
    [CreateAssetMenu(
        fileName = "energy-settings",
        menuName = SOPathConst.ConfigPath + "energy-settings",
        order = 100)]
    public class EnergySettings : SettingsSO
    {

        [Header("Defaults")] [Range(100, 1000)]
        public float energyLimit = 100;

        [Range(1f, 10f)] [Tooltip("Default: maxEnergy * 3 per day")]
        public float dailyEnergyExpenditureMultiplier = 3f;
    }
}
