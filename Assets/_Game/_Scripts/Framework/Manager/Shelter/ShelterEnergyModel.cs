using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    [MessagePackObject]
    public struct ShelterEnergyDto
    {
        [Key(0)] public int MaxEnergy;
        [Key(1)] public int CurrentEnergy;
    }

    public class ShelterEnergyModel : SavableDataModelBase<ShelterEnergyDto>
    {
    }
}
