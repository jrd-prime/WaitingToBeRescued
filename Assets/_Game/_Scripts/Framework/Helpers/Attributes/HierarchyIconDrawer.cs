﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace _Game._Scripts.Framework.Helpers.Attributes
{
    [InitializeOnLoad]
    public static class HierarchyIconDrawer
    {
        private static readonly Texture2D RequiredIcon =
            AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/_Game/Res/Textures/Icons/icon-required.png");

        private static readonly Dictionary<Type, FieldInfo[]> CachedFieldInfo = new();

        static HierarchyIconDrawer()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
        }

        private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            if (EditorUtility.InstanceIDToObject(instanceID) is not GameObject gameObject) return;

            // Use GetComponentsInChildren to include components on children
            foreach (var component in gameObject.GetComponents<Component>())
            {
                if (component == null) continue;

                var fields = GetCachedFieldsWithRequiredAttribute(component.GetType());
                if (fields == null) continue;

                if (fields.Any(field => IsFieldUnassigned(field.GetValue(component))))
                {
                    var iconRect = new Rect(selectionRect.xMax - 20, selectionRect.y, 16, 16);
                    GUI.Label(iconRect,
                        new GUIContent(RequiredIcon, "One or more required fields are missing or empty."));
                    break;
                }
            }
        }

        private static FieldInfo[] GetCachedFieldsWithRequiredAttribute(Type componentType)
        {
            if (!CachedFieldInfo.TryGetValue(componentType, out FieldInfo[] fields))
            {
                fields = componentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                List<FieldInfo> requiredFields = new();

                foreach (FieldInfo field in fields)
                {
                    bool isSerialized = field.IsPublic || field.IsDefined(typeof(SerializeField), false);
                    bool isRequired = field.IsDefined(typeof(RequiredFieldAttribute), false);

                    if (isSerialized && isRequired)
                    {
                        requiredFields.Add(field);
                    }
                }

                fields = requiredFields.ToArray();
                CachedFieldInfo[componentType] = fields;
            }

            return fields;
        }

        private static bool IsFieldUnassigned(object fieldValue)
        {
            if (fieldValue == null) return true;

            if (fieldValue is string stringValue && string.IsNullOrEmpty(stringValue)) return true;

            if (fieldValue is System.Collections.IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    if (item == null) return true;
                }
            }

            return false;
        }
    }
}
