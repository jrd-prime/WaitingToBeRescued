namespace _Game._Scripts.Framework.Data.Constants
{
    public static class SOPathConst
    {
        // Names
        private const string MainMenu = "WTBR/";
        private const string Config = "settings/";
        private const string UI = "ui/";
        private const string Character = "character/";
        private const string Interactable = "interactable/";

        // Paths
        public const string ConfigPath = MainMenu + Config;
        public const string CharacterPath = MainMenu + Config + Character;
        public const string UIPath = MainMenu + Config + UI;
        public const string WorldObject = MainMenu + Config + Interactable + "WorldObject/";
        public const string InGameItem = MainMenu  + "In Game Item/";
    }
}
