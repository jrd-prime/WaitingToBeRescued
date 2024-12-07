using _Game._Scripts.Framework.Data.SO.Interactable;

namespace _Game._Scripts.Interactable.WorldObject
{
    public abstract class WorldItemBase<TSettings> : ItemBase<TSettings> where TSettings : WorldItemSettingsBase
    {
    }
}
