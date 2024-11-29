using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter.Energy
{
    [MessagePackObject]
    public struct ShelterEnergyData
    {
        [Key(0)] public float MaxEnergy;
        [Key(1)] public float CurrentEnergy;
    }

    public class ShelterEnergyModel : SavableModelBase<EnergySettings, ShelterEnergyData>
    {
        protected override ShelterEnergyData GetDefaultModelData()
        {
            return new ShelterEnergyData
            {
                CurrentEnergy = ModelSettings.energyLimit,
                MaxEnergy = ModelSettings.energyLimit
            };
        }

        protected override string GetDebugLine()
        {
            return
                $"current energy {ModelData.CurrentValue.CurrentEnergy} / max energy {ModelData.CurrentValue.MaxEnergy}";
        }
    }
}
