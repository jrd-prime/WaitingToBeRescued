using MessagePack;
using UnityEngine;

namespace _Game._Scripts.Framework.Shelter.DayTimer
{
    [MessagePackObject]
    public sealed class DayTimerData : IDataComponent
    {
        [Key(0)] public int Day { get; private set; }
        [Key(1)] public float DayDuration { get; private set; }
        [Key(2)] public float RemainingTime { get; private set; }

        public DayTimerData(int day, float dayDuration, float remainingTime)
        {
            Day = day;
            DayDuration = dayDuration;
            RemainingTime = remainingTime;
        }

        public void AddDay() => Day++;
        public void SetRemainingTime(float remainingTime) => RemainingTime = remainingTime;
        public void SetDayDuration(float dayDuration) => DayDuration = dayDuration;

        public void ShowDebug()
        {
            Debug.LogWarning($"day {Day} / remaining time {RemainingTime} / day duration {DayDuration}");
        }
    }
}
