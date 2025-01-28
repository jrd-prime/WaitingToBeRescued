using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Tickers.DayTimer;
using UnityEngine;

namespace _Game._Scripts.Framework.Tickers.Energy
{
    public class PreparedEnergyData
    {
        public string EnergyValueFormatted { get; set; }
        public float EnergyBarWidthPercent { get; set; }
        public float EnergyMax { get; set; }
    }

    public class EnergyUpdater : UpdaterBase<EnergySavableData, PreparedEnergyData>
    {

        public override PreparedEnergyData Update(EnergySavableData savableData)
        {
            var current = savableData.Current;
            var max = savableData.Max;

            SetEnergyValueText(current, max);

            if (current <= 0)
            {
                Debug.LogWarning("NO ENERGY");
                PreparedData.EnergyMax = max;
            }

            PreparedData.EnergyBarWidthPercent = current / max;

            return PreparedData;
        }

        private void SetEnergyValueText(float current, float max)
        {
            PreparedData.EnergyValueFormatted = TextFormatter.EnergyValue(current, max);
        }
    }
}
