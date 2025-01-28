using System;
using _Game._Scripts.Framework.Data.SO;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Data
{
    [Serializable]
    public struct CustomItemValue<T> where T : InGameObjectSO
    {
        public T itemSettings;
        public float value;

    }
}
