using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using R3;
using UnityEngine;

namespace _Game._Scripts.Framework.Manager.Shelter.DayTimer
{
    public class PreparedDayTimerData
    {
        public int Day { get; set; }
        public float DayDuration { get; set; }
        public float DayBarWidthPercent { get; set; }
        public string RemainingTimeFormatted { get; set; }
    }

    public class DayCountdownUpdater : UpdaterBase<DayTimerData, PreparedDayTimerData>
    {
        private string _currentRemainingTime;
        private float _currentDayDuration;
        private int _currentDay;

        public override PreparedDayTimerData Update(DayTimerData rawData)
        {
            if (rawData == null) throw new ArgumentNullException(nameof(rawData));

            var day = rawData.Day;
            var dayDuration = rawData.DayDuration;
            var remainingTime = rawData.RemainingTime;

            if (PreparedData.Day != day) PreparedData.Day = day;

            if (Math.Abs(PreparedData.DayDuration - dayDuration) > JMathConst.Epsilon)
                PreparedData.DayDuration = dayDuration;

            PreparedData.DayBarWidthPercent = remainingTime / dayDuration;

            var formatted = TextFormatter.DayTimeCountdown(remainingTime);
            if (PreparedData.RemainingTimeFormatted != formatted) PreparedData.RemainingTimeFormatted = formatted;

            return PreparedData;
        }
    }

    public abstract class UpdaterBase<TRawData, TPreparedData> : IDataUpdater<TRawData, TPreparedData>
        where TRawData : IDataComponent where TPreparedData : new()
    {
        protected readonly TPreparedData PreparedData = new();
        public abstract TPreparedData Update(TRawData rawData);
    }

    public interface IDataUpdater<in TRawData, out TPreparedData> where TRawData : IDataComponent
    {
        public TPreparedData Update(TRawData rawData);
    }
}
