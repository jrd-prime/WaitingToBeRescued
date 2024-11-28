using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.Manager.Shelter
{
    public class GameTimeModel : SavableModelBase<GameTimerSettings, GameTimeDto>
    {
        protected override GameTimeDto GetDefaultModelData()
        {
            throw new System.NotImplementedException();
        }
    }

    public class GameTimerSettings : SettingsSO
    {
        public override string Description => "GameTimerSettings";
        public int startDay = 0;
        public float gameDayInSeconds = 60;
    }

    [MessagePackObject]
    public class GameTimeDto
    {
        [Key(0)] public int Day { get; private set; }
        [Key(1)] public float RemainingDayTime { get; private set; }

        public GameTimeDto(int day, float remainingTime)
        {
            Day = day;
            RemainingDayTime = remainingTime;
        }

        public void SetRemainingDayTime(float gameDayTime) => RemainingDayTime = gameDayTime;
        public void SetDay(int gameDay) => Day = gameDay;
    }
}
