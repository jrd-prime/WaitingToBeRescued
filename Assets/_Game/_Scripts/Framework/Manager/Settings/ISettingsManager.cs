using System;
using System.Collections.Generic;
using _Game._Scripts.Bootstrap;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO._Base;

namespace _Game._Scripts.Framework.Manager.Settings
{
    public interface ISettingsManager : ILoadingOperation
    {
        public Dictionary<Type, object> ConfigsCache { get; }
        public T GetConfig<T>() where T : SettingsSO;
    }
}
