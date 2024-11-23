using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Manager.Localization;
using _Game._Scripts.UI.Base.ViewModel;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class SubViewBase<T> : MonoBehaviour where T : IUIViewModel
    {
        [Inject]
        private void Construct(T viewModel, ILocalizationManager localizationManager)
        {
            ViewModel = viewModel;
            LocalizationManager = localizationManager;
        }

        [SerializeField] protected string headerNameId;
        [SerializeField] private VisualTreeAsset template;
        private TemplateContainer _template;
        protected bool _isInitialized;
        [SerializeField] public bool inSafeZone;

        protected T ViewModel { get; private set; }
        protected ILocalizationManager LocalizationManager { get; private set; }
        protected VisualElement ContentContainer;
        protected readonly CompositeDisposable Disposables = new();

        protected readonly Dictionary<Button, EventCallback<ClickEvent>> CallbacksCache = new();

        private void Awake()
        {
            _template = template.Instantiate();

            if (template == null) throw new NullReferenceException("Template is null. " + name);

            ContentContainer = _template.Q<VisualElement>(UIElementId.MainContentContainerId) ??
                               throw new NullReferenceException(
                                   $"{UIElementId.MainContentContainerId} not found. {name} / {template.name}");


            // if (LocalizationManager == null) throw new NullReferenceException("LocalizationManager is null. " + name);

            InitializeView();
            InitializeCallbacks();
            RegisterCallbacks();

            _isInitialized = true;
        }

        private void RegisterCallbacks()
        {
            foreach (var callback in CallbacksCache)
                callback.Key.RegisterCallback(callback.Value);
        }

        private void UnregisterCallbacks()
        {
            Debug.LogWarning("unreg callbacks " + name);
            foreach (var callback in CallbacksCache)
                callback.Key.UnregisterCallback(callback.Value);
        }

        protected abstract void InitializeView();
        protected abstract void InitializeCallbacks();

        public TemplateContainer GetTemplate()
        {
            if (!_isInitialized) throw new Exception("View is not initialized. " + name);
            return _template;
        }
    }
}
