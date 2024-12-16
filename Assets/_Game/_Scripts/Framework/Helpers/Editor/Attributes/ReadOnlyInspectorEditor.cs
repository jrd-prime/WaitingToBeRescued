using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace _Game._Scripts.Framework.Helpers.Editor.Attributes
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class ReadOnlyInspectorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var serializedObject1 = new SerializedObject(target);
            var propertyIterator = serializedObject1.GetIterator();

            while (propertyIterator.NextVisible(true))
            {
                // Получаем информацию о поле через FieldInfo
                FieldInfo fieldInfo = target.GetType().GetField(propertyIterator.name);
                bool isReadOnly = false;

                if (fieldInfo != null)
                {
                    // Проверяем наличие атрибута ReadOnly на поле
                    var attributes = fieldInfo.GetCustomAttributes(typeof(ReadOnlyAttribute), true);
                    isReadOnly = attributes.Length > 0;
                }

                if (isReadOnly)
                {
                    GUI.enabled = false; // Делает поле только для чтения
                }

                // Отображаем поле в инспекторе
                EditorGUILayout.PropertyField(propertyIterator, true);

                // Восстанавливаем возможность редактирования
                GUI.enabled = true;
            }

            serializedObject1.ApplyModifiedProperties();
        }
    }
}
