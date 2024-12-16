using System;
using _Game._Scripts.Framework.Helpers.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.Manager.UI.Viewer
{
    [RequireComponent(typeof(UIDocument))]
    public class UIViewerBase : MonoBehaviour, IUIViewer
    {
        protected VisualElement RootVisualElement { get; private set; }
        protected VisualElement RootContainer { get; private set; }
        protected VisualElement BackLayer { get; private set; }
        protected VisualElement MainLayer { get; private set; }
        protected VisualElement TopLayer { get; private set; }

        private void Awake()
        {
            RootVisualElement = GetComponent<UIDocument>().rootVisualElement;
            RootContainer = RootVisualElement.Q<VisualElement>("viewer-container") ??
                            throw new NullReferenceException("Viewer container not found");

            BackLayer = RootContainer.Q<VisualElement>("back-layer").CheckOnNull();
            MainLayer = RootContainer.Q<VisualElement>("main-layer").CheckOnNull();
            TopLayer = RootContainer.Q<VisualElement>("top-layer").CheckOnNull();
        }
    }
}
