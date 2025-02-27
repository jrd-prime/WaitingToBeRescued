﻿using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;

namespace _Game._Scripts.Framework.PlayerStuff._Base
{
    public abstract class StuffBase<TSettings, TSavableDto> : SavableDataModelBase<TSettings, TSavableDto>
        where TSettings : SettingsSO where TSavableDto : ISavableData
    {
    }
}
