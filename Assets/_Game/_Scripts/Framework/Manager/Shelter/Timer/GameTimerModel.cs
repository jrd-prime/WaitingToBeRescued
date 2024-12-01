using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter.Timer
{
    public class GameTimerModel : SavableModelBase<GameTimerSettings, GameTimerData>
    {
        protected override GameTimerData GetDefaultModelData()
        {
            return new GameTimerData(
                ModelSettings.startDay,
                ModelSettings.gameDayInSeconds,
                GameTimerSettings.gameDayInSeconds);
        }

        protected override string GetDebugLine() => $"day {GetDay()} / remaining time {GetRemainingTime()}";

        public int GetDay() => ModelData.CurrentValue.Day;

        public float GetRemainingTime() => ModelData.CurrentValue.RemainingTime;
        public float GetDayDuration() => ModelData.CurrentValue.DayDuration;
    }

    [MessagePackObject]
    public struct GameTimerData
    {
        [Key(0)] public int Day { get; set; }
        [Key(1)] public float RemainingTime { get; set; }
        [Key(2)] public float DayDuration { get; set; }

        public GameTimerData(int day, float remainingTime, float dayDuration)
        {
            Day = day;
            RemainingTime = remainingTime;
            DayDuration = dayDuration;
        }
    }
}
