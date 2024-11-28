using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    public class GameTimeModel : SavableModelBase<GameTimerSettings, GameTimeDto>
    {
        protected override void ShowDebug()
        {
            Debug.LogWarning($"Seted : {ModelData.CurrentValue.Day} / {ModelData.CurrentValue.RemainingTime}");
        }

        protected override GameTimeDto GetDefaultModelData()
        {
            // default game time data
            var _gameTimeData = new GameTimeDto(ModelSettings.startDay, ModelSettings.gameDayInSeconds);


            return _gameTimeData;
        }
    }

    [MessagePackObject]
    public struct GameTimeDto
    {
        [Key(0)] public int Day { get; set; }
        [Key(1)] public float RemainingTime { get; set; }

        public GameTimeDto(int day, float remainingTime)
        {
            Day = day;
            RemainingTime = remainingTime;
        }
    }
}
