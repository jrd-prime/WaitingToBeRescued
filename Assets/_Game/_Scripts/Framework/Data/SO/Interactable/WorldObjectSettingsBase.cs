namespace _Game._Scripts.Framework.Data.SO.Interactable
{
    public abstract class WorldObjectSettingsBase : SettingsSO
    {
        public EWorldObjectType worldObjectType = default;
    }


    public enum EResource
    {
        NotSet = 0,
        Wood = 1
    }

    public enum EWorldObjectType
    {
        NotSet = 0,
        Building = 1,
        Resource = 2
    }
}
