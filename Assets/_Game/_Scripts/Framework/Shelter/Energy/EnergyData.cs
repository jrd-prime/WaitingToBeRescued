using MessagePack;

namespace _Game._Scripts.Framework.Shelter.Energy
{
    [MessagePackObject]
    public sealed class EnergyData : IDataComponent
    {
        [Key(0)] public float Max { get; private set; }
        [Key(1)] public float Current { get; private set; }
        [Key(2)] public float ConsumptionPerSecond { get; private set; }

        public EnergyData(float max, float current, float consumptionPerSecond)
        {
            Max = max;
            Current = current;
            ConsumptionPerSecond = consumptionPerSecond;
        }

        public void SetCurrent(float value) => Current = value;
        public void SetEnergyLimit(float value) => Max = value;
        public void SetConsumptionPerSecond(float value) => ConsumptionPerSecond = value;
    }
}
