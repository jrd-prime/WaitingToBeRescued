using System;
using UnityEngine.UIElements;

namespace _Game._Scripts.NewUI
{
    public class UIViewer : UIViewerBase
    {
        public void ShowView(TemplateContainer view)
        {
            if (view == null) throw new NullReferenceException("View is null.");
            view.style.position = Position.Absolute;
            view.style.left = 0;
            view.style.top = 0;
            view.style.right = 0;
            view.style.bottom = 0;
            
            RootContainer.Clear();
            RootContainer.Add(view);
        }
    }
}
