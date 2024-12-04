using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter.DayTimer;
using R3;

namespace _Game._Scripts.Framework.Manager.Shelter.Energy
{
    public class PreparedEnergyData
    {
        public string EnergyValueFormatted { get; set; }
        public float EnergyBarWidthPercent { get; set; }
        public float EnergyMax { get; set; }
    }

    public class EnergyUpdater : UpdaterBase<EnergyData, PreparedEnergyData>
    {
        private float _currentEnergyMax;

        public override PreparedEnergyData Update(EnergyData data)
        {
            var current = data.Current;
            var max = data.Max;

            SetEnergyValueText(current, max);

            if (current <= 0)
            {
                _currentEnergyMax = max;
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
