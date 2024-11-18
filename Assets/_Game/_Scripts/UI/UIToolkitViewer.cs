using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class UIToolkitViewer : MonoBehaviour
    {
        private VisualElement _root;
        private VisualElement _container;
        private UIDocument _document;

        private void Awake()
        {
            _document = GetComponent<UIDocument>();
            _root = _document.rootVisualElement;
            _container = _root.Q<VisualElement>("container");
            if (_container == null) throw new NullReferenceException("Container is null.");
        }

        public void ShowView(TemplateContainer view)
        {
            Debug.LogWarning(" show view  in viewer " + name);
            if (view == null) throw new NullReferenceException("View is null.");
            view.style.position = Position.Absolute;
            view.style.left = 0;
            view.style.top = 0;
            view.style.right = 0;
            view.style.bottom = 0;

            _container.Clear();
            _container.Add(view);
        }
    }
}
