using System;
using _Game._Scripts.Framework.Data;
using _Game._Scripts.Framework.Helpers;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.Manager.UI.Viewer
{
    public class UIViewer : UIViewerBase
    {
        [Header("Debug"), SerializeField] private bool showDebugLog;


        private void ToSafe()
        {
            var safeZoneOffset = ScreenHelper.GetSafeZoneOffset(800f, 360f);
            RootVisualElement.style.marginLeft = safeZoneOffset.x >= 16 ? safeZoneOffset.x : 16;
            RootVisualElement.style.marginTop = safeZoneOffset.y;
        }


        private void Prepare(SubViewDto subViewDto)
        {
            Log("<color=yellow>[VIEWER]</color> Prepare to show view");

            var view = subViewDto.Template;
            if (view == null) throw new NullReferenceException("View is null.");

            if (subViewDto.InSafeZone) ToSafe();

            view.style.position = Position.Absolute;
            view.style.left = 0;
            view.style.top = 0;
            view.style.right = 0;
            view.style.bottom = 0;
        }

        private void ClearAll()
        {
            BackLayer.Clear();
            MainLayer.Clear();
            TopLayer.Clear();
        }

        public void ShowNewBase(SubViewDto subViewDto)
        {
            Prepare(subViewDto);
            HideView();
            MainLayer.Add(subViewDto.Template);
        }

        public void ShowOverSubView(SubViewDto subViewDto)
        {
            Log($"show over sub view: {subViewDto.Template}");
            Prepare(subViewDto);
            TopLayer.Add(subViewDto.Template);
        }

        public void ShowUnderSubView(SubViewDto subViewDto)
        {
            Prepare(subViewDto);
            BackLayer.Add(subViewDto.Template);
        }

        public void HideView() => ClearAll();

        private void Log(string message)
        {
            if (showDebugLog) Debug.LogWarning(message);
        }
    }
}
