using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.NewUI
{
    [RequireComponent(typeof(UIDocument))]
    public class UIViewerBase : MonoBehaviour, IUIViewer
    {
        protected VisualElement RootVisualElement { get; private set; }
        protected VisualElement RootContainer { get; private set; }

        private void Awake()
        {
            RootVisualElement = GetComponent<UIDocument>().rootVisualElement;
            RootContainer = RootVisualElement.Q<VisualElement>("viewer-container") ??
                            throw new NullReferenceException("Viewer container not found");
        }
    }
}
