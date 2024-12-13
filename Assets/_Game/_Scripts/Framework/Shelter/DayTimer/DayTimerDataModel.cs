using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.SO.Game;
using _Game._Scripts.Framework.Systems.SaveLoad;

namespace _Game._Scripts.Framework.Shelter.DayTimer
{
    public class DayTimerDataModel : SavableDataModelBase<GameTimerSettings, DayTimerData>
    {
        private int _startDay;
        private float _dayDuration;

        protected override void InitModel()
        {
            _startDay = GameplaySettings.startDay;
            _dayDuration = ModelSettings.gameDayInSeconds;
        }

        protected override string GetDebugLine()
        {
            return
                $"day: {CachedModelData.Day} / remaining: {CachedModelData.RemainingTime} / day duration {CachedModelData.DayDuration}";
        }

        public void SetRemainingTime(float value)
        {
            if (!(Math.Abs(CachedModelData.RemainingTime - value) > JMathConst.Epsilon)) return;

            CachedModelData.SetRemainingTime(value);
            OnModelDataUpdated();
        }

        public void AddDay()
        {
            CachedModelData.AddDay();
            OnModelDataUpdated();
        }

        public void SetDayDuration(float value)
        {
            CachedModelData.SetDayDuration(value);
            OnModelDataUpdated();
        }

        public float GetRemainingTime() => CachedModelData.RemainingTime;
        protected override DayTimerData GetDefaultModelData() => new(_startDay, _dayDuration, _dayDuration);
    }
}
