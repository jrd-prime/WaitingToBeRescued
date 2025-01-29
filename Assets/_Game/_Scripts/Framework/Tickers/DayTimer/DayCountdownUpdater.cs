using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Systems.SaveLoad;

namespace _Game._Scripts.Framework.Tickers.DayTimer
{
    public class PreparedDayTimerData
    {
        public int Day { get; set; }
        public float DayDuration { get; set; }
        public float DayBarWidthPercent { get; set; }
        public string RemainingTimeFormatted { get; set; }
    }

    public class DayCountdownUpdater : UpdaterBase<DayTimerSavableData, PreparedDayTimerData>
    {
        public override PreparedDayTimerData Update(DayTimerSavableData rawSavableData)
        {
            if (rawSavableData == null) throw new ArgumentNullException(nameof(rawSavableData));

            var day = rawSavableData.Day;
            var dayDuration = rawSavableData.DayDuration;
            var remainingTime = rawSavableData.RemainingTime;

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
        where TRawData : ISavableData where TPreparedData : new()
    {
        protected readonly TPreparedData PreparedData = new();
        public abstract TPreparedData Update(TRawData rawData);
    }

    public interface IDataUpdater<in TRawData, out TPreparedData> where TRawData : ISavableData
    {
        public TPreparedData Update(TRawData rawData);
    }
}
