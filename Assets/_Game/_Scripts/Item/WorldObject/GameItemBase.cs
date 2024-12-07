using _Game._Scripts.Framework.Data.SO.Interactable;

namespace _Game._Scripts.Interactable.WorldObject
{
    public abstract class GameItemBase<TSettings> : ItemBase<TSettings> where TSettings : GameItemSettingsBase
    {
        public EResource Resource;
    }
}
