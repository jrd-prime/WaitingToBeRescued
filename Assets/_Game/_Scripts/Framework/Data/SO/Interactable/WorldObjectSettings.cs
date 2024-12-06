using System;

namespace _Game._Scripts.Framework.Data.SO.Interactable
{
    public abstract class WorldObjectSettings<TSettings> : WorldObjectSettingsBase where TSettings : SettingsSO
    {
        public TSettings type = default;
    }
}
