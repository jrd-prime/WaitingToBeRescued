﻿using System.Collections.Generic;
using _Game._Scripts.Framework.Data.DTO;
using _Game._Scripts.Framework.Data.SO._Base;

namespace _Game._Scripts.Framework.Helpers
{
    public static class ItemsLogHelper
    {
        public static void LogItems<T>(this List<CustomItemValue<T>> items, string itemType)
            where T : InGameObjectSettings
        {
            foreach (var item in items)
            {
                UnityEngine.Debug.LogWarning($"{itemType} {item.itemSettings.name} : {item.value}");
            }
        }
    }
}
