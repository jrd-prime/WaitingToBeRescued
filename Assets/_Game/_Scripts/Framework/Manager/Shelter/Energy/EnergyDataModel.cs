using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter.Energy
{
    [MessagePackObject]
    public struct ShelterEnergyData
    {
        [Key(0)] public float Max;
        [Key(1)] public float Current;
        [Key(2)] public float ConsumptionPerSecond;
    }

    public class EnergyDataModel : SavableDataModelBase<EnergySettings, ShelterEnergyData>
    {
        private float _lastTimeRemaining;

        public void AddEnergy(float amount)
        {
            var newEnergy = Mathf.Clamp(GetCurrent() + amount, 0, GetMax());

            OnModelDataUpdated(new ShelterEnergyData
            {
                Current = newEnergy,
                Max = GetMax(),
                ConsumptionPerSecond = GetConsumptionPerSecond()
            });
        }

        public void OnTimerTick(float timeRemaining)
        {
            var dayBase = GameTimerSettings.gameDayInSeconds;
            
            var current = GetCurrent();
            var max = GetMax();
            
            var consumptionPerSecond = GetMax() * ModelSettings.dailyEnergyExpenditureMultiplier / dayBase;
            
            var timeDelta = _lastTimeRemaining - timeRemaining;
            
            var energyUsed = timeDelta * consumptionPerSecond;
            
            current -= energyUsed;
            
            current = Mathf.Clamp(current, 0, max);
            
            _lastTimeRemaining = timeRemaining;
            
            OnModelDataUpdated(new ShelterEnergyData
            {
                Current = current,
                Max = max,
                ConsumptionPerSecond = consumptionPerSecond
            });
        }

        protected override ShelterEnergyData GetDefaultModelData()
        {
            var max = ModelSettings.energyLimit;
            var consumptionPerSecond = max * ModelSettings.dailyEnergyExpenditureMultiplier /
                                       GameTimerSettings.gameDayInSeconds;

            return new ShelterEnergyData
            {
                Current = max,
                Max = max,
                ConsumptionPerSecond = consumptionPerSecond
            };
        }

        protected override string GetDebugLine()
        {
            return $"current energy {ModelData.CurrentValue.Current} / max energy {ModelData.CurrentValue.Max}";
        }

        private float GetMax() => ModelData.CurrentValue.Max;
        private float GetCurrent() => ModelData.CurrentValue.Current;
        private float GetConsumptionPerSecond() => ModelData.CurrentValue.ConsumptionPerSecond;
    }
}
