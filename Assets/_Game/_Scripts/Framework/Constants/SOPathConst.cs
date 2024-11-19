namespace _Game._Scripts.Framework.Constants
{
    public static class SOPathConst
    {
        // Names
        private const string MainMenu = "WTBR/";
        private const string Config = "settings/";
        private const string UI = "ui/";
        private const string Character = "character/";

        // Paths
        public const string ConfigPath = MainMenu + Config;
        public const string CharacterPath = MainMenu + Config + Character;
        public const string UIPath = MainMenu + Config + UI;
    }
}
