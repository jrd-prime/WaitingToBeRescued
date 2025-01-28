using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Framework.Tickers.Energy
{
    [MessagePackObject]
    public sealed class EnergySavableData : ISavableData
    {
        [Key(0)] public float Max { get; private set; }
        [Key(1)] public float Current { get; private set; }
        [Key(2)] public float ConsumptionPerSecond { get; private set; }
        [Key(3)] public bool OutOfEnergy { get; private set; }

        public EnergySavableData(float max, float current, float consumptionPerSecond, bool outOfEnergy = false)
        {
            Max = max;
            Current = current;
            ConsumptionPerSecond = consumptionPerSecond;
            OutOfEnergy = outOfEnergy;
        }

        public void SetCurrent(float value)
        {
            Current = Mathf.Clamp(value, 0, Max);
            IsEnergyEmpty(value <= 0);
        }

        public void SetEnergyLimit(float value) => Max = value;
        public void SetConsumptionPerSecond(float value) => ConsumptionPerSecond = value;
        private void IsEnergyEmpty(bool b) => OutOfEnergy = b;
    }
}
