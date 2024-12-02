using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter.Temperature
{
    [MessagePackObject]
    public struct AmbientTempData
    {
        [Key(0)] public float Current;
        [Key(1)] public float NextChange;
    }

    public class AmbientTemperatureDataModel : SavableDataModelBase<TemperatureSettings, AmbientTempData>
    {
        protected override AmbientTempData GetDefaultModelData()
        {
            return new AmbientTempData
            {
                Current = ModelSettings.startTempInCelsius,
                NextChange = GameplaySettings.baseDailyTemperatureDrop,
            };
        }

        protected override string GetDebugLine()
        {
            return $" current {ModelData.CurrentValue.Current} / next change {ModelData.CurrentValue.NextChange}";
        }

        public void OnNewDay()
        {
            var newData = new AmbientTempData
            {
                Current = GetCurrentTemp() - GetNexChange(),
                NextChange = GetNexChange()
            };

            OnModelDataUpdated(newData);
        }

        private float GetNexChange() => ModelData.CurrentValue.NextChange;

        private float GetCurrentTemp() => ModelData.CurrentValue.Current;
    }
}
