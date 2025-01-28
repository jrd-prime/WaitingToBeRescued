using MessagePack;

namespace _Game._Scripts.Framework.Tickers.Temperature
{
    [MessagePackObject]
    public sealed class AmbientTempSavableData : ISavableData
    {
        [Key(0)] public float Current { get; private set; }
        [Key(1)] public float NextChange { get; private set; }

        public AmbientTempSavableData(float current, float nextChange)
        {
            Current = current;
            NextChange = nextChange;
        }

        public void SetCurrent(float value) => Current = value;
        public void SetNextChange(float value) => NextChange = value;
    }
}
