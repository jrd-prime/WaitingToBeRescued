using System;
using _Game._Scripts.Framework.Data.SO._Base;

namespace _Game._Scripts.Framework.Data.DTO
{
    [Serializable]
    public struct CustomItemValue<T> where T : SettingsSO
    {
        public T itemSettings;
        public float value;
    }
}
