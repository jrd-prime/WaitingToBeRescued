using System;

namespace _Game._Scripts.Framework.Data.SO.Interactable
{
    public abstract class ResourceSettingsBase<TEnum> : SettingsSO where TEnum : Enum
    {
        public TEnum resource;
    }
}
