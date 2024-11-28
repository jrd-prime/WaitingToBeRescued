using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter.Temperature
{
    [MessagePackObject]
    public struct AmbientTempDto
    {
        [Key(0)] public float Current;
        [Key(1)] public float NextChange;
        [Key(2)] public float TimeToNextChange;
    }

    public class AmbientTemperatureModel : SavableModelBase<TemperatureSettings, AmbientTempDto>
    {
        protected override void ShowDebug()
        {
            
        }

        protected override AmbientTempDto GetDefaultModelData()
        {
            return new AmbientTempDto
            {
                Current = ModelSettings.startTempInCelsius,
                NextChange = GameplaySettings.baseDailyTemperatureDrop,
                TimeToNextChange = GameplaySettings.gameDayInSeconds
            };
        }
    }
}
