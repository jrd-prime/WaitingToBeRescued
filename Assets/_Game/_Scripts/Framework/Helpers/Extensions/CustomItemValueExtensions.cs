using System.Collections.Generic;
using System.Linq;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;

namespace _Game._Scripts.Framework.Helpers.Extensions
{
    public static class CustomItemValueExtensions
    {
        public static Dictionary<int, float> ToIdValueDict<T>(this List<CustomItemValue<T>> list)
            where T : InGameObjectSO
        {
            return list.ToDictionary(item => item.itemSettings.GetID(), item => item.value);
        }
    }
}
