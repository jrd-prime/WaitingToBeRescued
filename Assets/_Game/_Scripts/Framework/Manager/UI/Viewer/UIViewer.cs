using System;
using _Game._Scripts.Framework.Helpers;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.Manager.UI.Viewer
{
    public class UIViewer : UIViewerBase
    {
        public void ShowView(TemplateContainer view, bool toSafe = false)
        {
            if (toSafe) ToSafe();

            if (view == null) throw new NullReferenceException("View is null.");
            view.style.position = Position.Absolute;
            view.style.left = 0;
            view.style.top = 0;
            view.style.right = 0;
            view.style.bottom = 0;

            RootContainer.Clear();
            RootContainer.Add(view);
        }

        private void ToSafe()
        {
            var safeZoneOffset = ScreenHelper.GetSafeZoneOffset(800f, 360f);
            RootVisualElement.style.marginLeft = safeZoneOffset.x >= 16 ? safeZoneOffset.x : 16;
            RootVisualElement.style.marginTop = safeZoneOffset.y;
        }

        public void HideView()
        {
           RootContainer.Clear();
        }
    }
}
