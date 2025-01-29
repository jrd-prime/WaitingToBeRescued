using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;

namespace _Game._Scripts.Framework.Interacts.WorldObjs.Data
{
    [Serializable]
    public struct CustomItemValue<T> where T : InGameObjectSO
    {
        public T itemSettings;
        public float value;
    }

    public static class CustomItemValueExtensions
    {
        public static Dictionary<int, float> ToIdValueDictionary<T>(this List<CustomItemValue<T>> list)
            where T : InGameObjectSO
        {
            var result = new Dictionary<int, float>();
            foreach (var item in list)
            {
                result.Add(item.itemSettings.GetID(), item.value);
            }

            return result;
        }
    }
}
