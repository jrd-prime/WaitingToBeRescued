using System;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.UI.Base.ViewModel;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.UIOLD.Base
{
    public abstract class UIView<T> : UIViewBase where T : IUIViewModel
    {
        [RequiredField, SerializeField] private VisualTreeAsset ViewVisualTreeAsset;
        protected VisualElement RootVisualElement;
        protected TemplateContainer _templateContainer;
        protected T ViewModel;

        [Inject]
        private void Construct(T viewModel)
        {
            Debug.LogWarning("construct view " + name);
            ViewModel = viewModel;

            if (ViewModel == null) throw new NullReferenceException($"{typeof(T)} is null");
        }

        public void Awake()
        {
            Debug.LogWarning("start view " + name);

            if (ViewVisualTreeAsset == null) throw new NullReferenceException($"ViewVisualTreeAsset is null. ({this})");
            _templateContainer = ViewVisualTreeAsset.Instantiate();


            Debug.LogWarning(_templateContainer + ": template  /// name " + name);

            RootVisualElement = _templateContainer ??
                                throw new NullReferenceException($"TemplateContainer is null. ({this})");

            Debug.LogWarning(RootVisualElement + ": root visual element  /// name " + name);

            InitElements();
            Init();
            InitCallbacksCache();
        }

        private void Start()
        {
            Debug.LogWarning("start view " + name);
            if (ViewModel == null)
                throw new NullReferenceException(
                    $"ViewModel ({typeof(T)}) in {name} is null. Check container registration!");
        }

        public TemplateContainer GetView()
        {
            Debug.LogWarning("get view " + name + " /// " + _templateContainer);
            RegisterCallbacks();
            return _templateContainer;
        }

        public override void Show()
        {
            RegisterCallbacks();
            Debug.LogWarning("show view " + name);
            // RootVisualElement.style.display = DisplayStyle.Flex;
        }

        public override void Hide()
        {
            // RootVisualElement.style.display = DisplayStyle.None;
            Debug.LogWarning("hide view " + name);
            UnregisterCallbacks();
        }
    }
}
