using System;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;

namespace _Game._Scripts.Framework.Manager.Shelter.DayTimer
{
    public class DayTimerDataModel : SavableDataModelBase<GameTimerSettings, DayTimerData>
    {
        protected override DayTimerData GetDefaultModelData() =>
            new(GameplaySettings.startDay, ModelSettings.gameDayInSeconds, GameTimerSettings.gameDayInSeconds);

        protected override string GetDebugLine()
        {
            return
                $"day {CurrentModelData.Day} / remaining time {CurrentModelData.RemainingTime} / day duration {CurrentModelData.DayDuration}";
        }

        public void SetRemainingTime(float value)
        {
            if (!(Math.Abs(CurrentModelData.RemainingTime - value) > JMathConst.Epsilon)) return;

            CurrentModelData.SetRemainingTime(value);
            OnModelDataUpdated(CurrentModelData);
        }

        public void AddDay()
        {
            CurrentModelData.AddDay();
            OnModelDataUpdated(CurrentModelData);
        }

        public void SetDayDuration(float value)
        {
            CurrentModelData.SetDayDuration(value);
            OnModelDataUpdated(CurrentModelData);
        }

        public float GetRemainingTime() => CurrentModelData.RemainingTime;
    }
}
