using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter.Energy
{
    public class EnergyDataModel : SavableDataModelBase<EnergySettings, EnergyData>
    {
        private float _lastTimeRemaining;
        private float _max;
        private float _consumptionPerSecond;
        private float _multiplier;
        private float _dayDuration;

        protected override void InitModel()
        {
            _max = ModelSettings.energyLimit;
            _multiplier = ModelSettings.dailyEnergyExpenditureMultiplier;
            _dayDuration = GameTimerSettings.gameDayInSeconds;
            _consumptionPerSecond = _max * _multiplier / _dayDuration;
        }

        protected override EnergyData GetDefaultModelData() => new(_max, _max, _consumptionPerSecond);

        public void AddEnergy(float amount)
        {
            var newEnergy = Mathf.Clamp(GetCurrent() + amount, 0, GetMax());

            CachedModelData.SetCurrent(newEnergy);
            OnModelDataUpdated();
        }

        public void OnTimerTick(float timeRemaining)
        {
            var current = CachedModelData.Current;
            var timeDelta = _lastTimeRemaining - timeRemaining;
            var energyUsed = timeDelta * _consumptionPerSecond;
            current -= energyUsed;
            current = Mathf.Clamp(current, 0, _max);
            _lastTimeRemaining = timeRemaining;

            CachedModelData.SetCurrent(current);
            OnModelDataUpdated();
        }

        public void IncreaseEnergyLimitTo(float value)
        {
            _max = value;
            _consumptionPerSecond = _max * _multiplier / _dayDuration;
            CachedModelData.SetEnergyLimit(_max);
            CachedModelData.SetConsumptionPerSecond(_consumptionPerSecond);
            OnModelDataUpdated();
        }

        protected override string GetDebugLine()
        {
            return
                $"current: {CachedModelData.Current} / max: {CachedModelData.Max} / -{CachedModelData.ConsumptionPerSecond}/sec";
        }

        private float GetMax() => CachedModelData.Max;
        private float GetCurrent() => CachedModelData.Current;
        private float GetConsumptionPerSecond() => CachedModelData.ConsumptionPerSecond;
    }
}
