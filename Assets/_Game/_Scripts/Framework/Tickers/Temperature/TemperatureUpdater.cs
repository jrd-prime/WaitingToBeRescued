using _Game._Scripts.Framework.Tickers.DayTimer;

namespace _Game._Scripts.Framework.Tickers.Temperature
{
    public class PreparedTemperatureData
    {
        public string Current { get; set; }
        public string NextChange { get; set; }
    }

    public class TemperatureUpdater : UpdaterBase<AmbientTempData, PreparedTemperatureData>
    {
        public override PreparedTemperatureData Update(AmbientTempData rawData)
        {
            var temp = rawData.Current;
            var curr = temp switch
            {
                > 0 => $"+{temp}",
                < 0 => $"{temp}",
                _ => $"{temp}"
            };
            PreparedData.Current = curr;
            PreparedData.NextChange = $"{rawData.NextChange}";
            return PreparedData;
        }
    }
}
