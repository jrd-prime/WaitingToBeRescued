using System;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.Helpers
{
    public static class VisualElementExtension
    {
        public static T CheckOnNull<T>(this T visualElement) where T : VisualElement
        {
            if (visualElement == null) throw new NullReferenceException("visualElement is null");
            return visualElement;
        }
    }
}
