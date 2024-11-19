﻿#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace _Game._Scripts.Framework.Helpers.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
    public class RequiredFieldDrawer : PropertyDrawer
    {
        private readonly Texture2D _requiredIcon =
            AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/_Game/Res/Textures/Icons/icon-required.png");

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.BeginChangeCheck();

            Rect fieldRect = new(position.x, position.y, position.width - 20, position.height);
            EditorGUI.PropertyField(fieldRect, property, label);

            // If the field is required but unassigned, show the icon
            if (IsFieldUnassigned(property))
            {
                Rect iconRect = new(position.xMax - 18, fieldRect.y, 16, 16);
                GUI.Label(iconRect,
                    new GUIContent(_requiredIcon, "This field is required and is either missing or empty!"));
            }

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(property.serializedObject.targetObject);

                // Force a repaint of the hierarchy
                EditorApplication.RepaintHierarchyWindow();
            }

            EditorGUI.EndProperty();
        }

        private static bool IsFieldUnassigned(SerializedProperty property)
        {
            switch (property.propertyType)
            {
                // Add additional types as necessary
                case SerializedPropertyType.ObjectReference when property.objectReferenceValue:
                case SerializedPropertyType.ExposedReference when property.exposedReferenceValue:
                case SerializedPropertyType.AnimationCurve when property.animationCurveValue is { length: > 0 }:
                case SerializedPropertyType.String when !string.IsNullOrEmpty(property.stringValue):
                    return false;
                default:
                    return true;
            }
        }
    }
}

#endif
