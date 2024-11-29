using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    public class GameTimerModel : SavableModelBase<GameTimerSettings, GameTimerData>
    {
        protected override GameTimerData GetDefaultModelData()
        {
            return new GameTimerData(ModelSettings.startDay, ModelSettings.gameDayInSeconds);
        }

        protected override string GetDebugLine() => $"day {GetDay()} / remaining time {GetRemainingTime()}";

        public int GetDay() => ModelData.CurrentValue.Day;

        public float GetRemainingTime() => ModelData.CurrentValue.RemainingTime;
    }

    [MessagePackObject]
    public struct GameTimerData
    {
        [Key(0)] public int Day { get; set; }
        [Key(1)] public float RemainingTime { get; set; }

        public GameTimerData(int day, float remainingTime)
        {
            Day = day;
            RemainingTime = remainingTime;
        }
    }
}
