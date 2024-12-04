namespace _Game._Scripts.Framework.Helpers
{
    public static class TextFormatter
    {
        public static string EnergyValue(float current, float max) => $"{current:F1} / {max}";

        public static string DayTimeCountdown(float remainingSeconds) =>
            $"{remainingSeconds.ToMinutes():D2}:{remainingSeconds.ToSeconds():D2}";
    }
}
