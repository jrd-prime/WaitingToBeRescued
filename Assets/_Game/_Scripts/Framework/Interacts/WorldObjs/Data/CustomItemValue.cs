using System;
using _Game._Scripts.Framework.Data.SO;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Data
{
    [Serializable]
    public struct CustomItemValue<T> where T : SettingsSO
    {
        public T itemSettings;
        public float value;
    }
}
