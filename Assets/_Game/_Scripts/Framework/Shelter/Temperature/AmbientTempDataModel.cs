using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;

namespace _Game._Scripts.Framework.Shelter.Temperature
{
    public class AmbientTempDataModel : SavableDataModelBase<TemperatureSettings, AmbientTempData>
    {
        private float _current;
        private float _nextChange;

        protected override void InitModel()
        {
            _current = ModelSettings.startTempInCelsius;
            _nextChange = ModelSettings.baseDailyTemperatureDrop;
        }

        protected override AmbientTempData GetDefaultModelData() => new(_current, _nextChange);


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
