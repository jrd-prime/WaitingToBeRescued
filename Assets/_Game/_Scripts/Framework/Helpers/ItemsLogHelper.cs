using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;

namespace _Game._Scripts.Framework.Helpers
{
    public static class ItemsLogHelper
    {
        public static void LogItems<T>(this List<CustomItemValue<T>> items, string itemType) where T : InGameObjectSO
        {
            foreach (var item in items)
            {
                UnityEngine.Debug.LogWarning($"{itemType} {item.itemSettings.name} : {item.value}");
            }
        }
    }
}
