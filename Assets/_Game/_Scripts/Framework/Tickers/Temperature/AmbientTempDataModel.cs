﻿using _Game._Scripts.Framework.Data.SO.Main;
using _Game._Scripts.Framework.Systems.SaveLoad;

namespace _Game._Scripts.Framework.Tickers.Temperature
{
    public class AmbientTempDataModel : SavableDataModelBase<TemperatureSettings, AmbientTempSavableData>
    {
        private float _current;
        private float _nextChange;

        protected override void InitializeDataModel()
        {
            _current = ModelSettings.startTempInCelsius;
            _nextChange = ModelSettings.baseDailyTemperatureDrop;
        }

        protected override AmbientTempSavableData GetDefaultModelData() => new(_current, _nextChange);


        protected override string GetDebugLine()
        {
            return $" current {CachedModelData.Current} / next change {CachedModelData.NextChange}";
        }

        public void OnNewDay()
        {
            CachedModelData.SetCurrent(CachedModelData.Current - CachedModelData.NextChange);
            OnModelDataUpdated();
        }

        public void SetNextChange(float value)
        {
            CachedModelData.SetNextChange(value);
            OnModelDataUpdated();
        }
    }
}
