using System;
using System.Collections.Generic;
using _Game._Scripts.Bootstrap;
using _Game._Scripts.Framework.SO;

namespace _Game._Scripts.Framework.Managers.Settings
{
    public interface ISettingsManager : ILoadingOperation
    {
        public Dictionary<Type, object> ConfigsCache { get; }
        public T GetConfig<T>() where T : SettingsSO;
    }
}
