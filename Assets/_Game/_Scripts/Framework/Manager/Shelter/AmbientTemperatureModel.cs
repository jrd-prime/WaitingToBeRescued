using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    [MessagePackObject]
    public struct AmbientTempDTO
    {
        [Key(0)] public float Current;
        [Key(1)] public float NextChange;
        [Key(2)] public float TimeToNextChange;
    }

    public class AmbientTemperatureModel : SavableDataModelBase<AmbientTempDTO>
    {
    }
}
