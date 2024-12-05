using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Systems.SaveLoad;
using UnityEngine;

namespace _Game._Scripts.Framework.Shelter.Energy
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
            _lastTimeRemaining = _dayDuration;

            _previousTimeRemaining = _dayDuration;
        }

        protected override EnergyData GetDefaultModelData() => new(_max, _max, _consumptionPerSecond);

        public void IncreaseEnergy(float amount)
        {
            var newEnergy = Mathf.Clamp(CachedModelData.Current + amount, 0, CachedModelData.Max);

            CachedModelData.SetCurrent(newEnergy);
            OnModelDataUpdated();
        }

        public void DecreaseEnergy(float amount)
        {
            var newEnergy = Mathf.Clamp(CachedModelData.Current - amount, 0, CachedModelData.Max);

            CachedModelData.SetCurrent(newEnergy);
            OnModelDataUpdated();
        }

        private float _previousTimeRemaining; // Для отслеживания предыдущего оставшегося времени

        public void OnTimerTick(float timeRemaining)
        {
            if (CachedModelData.OutOfEnergy)
            {
                _previousTimeRemaining = timeRemaining;
                return;
            }

            var timePassed = IsNewDayStarted(timeRemaining)
                ? _previousTimeRemaining + _dayDuration - timeRemaining
                : _previousTimeRemaining - timeRemaining;

            float energyConsumed = _consumptionPerSecond * timePassed;
            Debug.LogWarning("consumption: " + _consumptionPerSecond);
            DecreaseEnergy(energyConsumed);
            _previousTimeRemaining = timeRemaining;
            OnModelDataUpdated();
        }

        private bool IsNewDayStarted(float timeRemaining) => timeRemaining > _previousTimeRemaining;

        public void IncreaseEnergyLimitTo(float value)
        {
            // _max = value;
            // _consumptionPerCycle = _max * _multiplier / _dayDuration;
            // CachedModelData.SetEnergyLimit(_max);
            // CachedModelData.SetConsumptionPerSecond(_consumptionPerCycle);
            // OnModelDataUpdated();
        }

        protected override string GetDebugLine()
        {
            return
                $"current: {CachedModelData.Current} / max: {CachedModelData.Max} / -{CachedModelData.ConsumptionPerSecond}/sec";
        }

        private float GetMax() => CachedModelData.Max;
        private float GetCurrent() => CachedModelData.Current;
        private float GetConsumptionPerSecond() => CachedModelData.ConsumptionPerSecond;

        public void OnNewDay()
        {
            _previousTimeRemaining = _dayDuration;
        }
    }
}
