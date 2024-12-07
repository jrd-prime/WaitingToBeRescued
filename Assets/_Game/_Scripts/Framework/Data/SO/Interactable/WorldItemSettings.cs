using System;

namespace _Game._Scripts.Framework.Data.SO.Interactable
{
    public abstract class WorldItemSettings<TSettings> : WorldItemSettingsBase where TSettings : SettingsSO
    {
        public TSettings type = default;
    }
}
