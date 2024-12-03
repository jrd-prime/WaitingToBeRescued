using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter.Temperature
{
    [MessagePackObject]
    public sealed class AmbientTempData
    {
        [Key(0)] public float Current { get; private set; }
        [Key(1)] public float NextChange { get; private set; }

        public AmbientTempData(float current, float nextChange)
        {
            Current = current;
            NextChange = nextChange;
        }

        public void SetCurrent(float value) => Current = value;
        public void SetNextChange(float value) => NextChange = value;
    }
}
