using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter.Energy
{
    [MessagePackObject]
    public struct ShelterEnergyDto
    {
        [Key(0)] public float MaxEnergy;
        [Key(1)] public float CurrentEnergy;
    }

    public class ShelterEnergyModel : SavableModelBase<EnergySettings, ShelterEnergyDto>
    {
        protected override void ShowDebug()
        {
            
            
        }

        protected override ShelterEnergyDto GetDefaultModelData()
        {
            return new ShelterEnergyDto
            {
                CurrentEnergy = ModelSettings.energyLimit,
                MaxEnergy = ModelSettings.energyLimit
            };
        }
    }
}
