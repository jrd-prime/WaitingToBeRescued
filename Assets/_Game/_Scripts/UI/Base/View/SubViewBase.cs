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
    public abstract class SubViewBase : MonoBehaviour
    {
        [SerializeField] protected string headerNameId;
        [SerializeField] protected VisualTreeAsset template;
        [SerializeField] public bool inSafeZone;
        protected readonly CompositeDisposable Disposables = new();
        protected readonly Dictionary<Button, EventCallback<ClickEvent>> CallbacksCache = new();

        protected TemplateContainer Template;
        protected bool IsInitialized;

        protected VisualElement ContentContainer;

        protected void RegisterCallbacks()
        {
            foreach (var callback in CallbacksCache)
                callback.Key.RegisterCallback(callback.Value);
        }

        protected void UnregisterCallbacks()
        {
            Debug.LogWarning("unreg callbacks " + name);
            foreach (var callback in CallbacksCache)
                callback.Key.UnregisterCallback(callback.Value);
        }

        protected abstract void InitializeView();
        protected abstract void InitializeCallbacks();

        public TemplateContainer GetTemplate()
        {
            if (!IsInitialized) throw new Exception("View is not initialized. " + name);
            return Template;
        }
    }

    public abstract class CustomSubViewBase<T> : SubViewBase where T : IUIViewModel
    {
        protected T ViewModel { get; private set; }
        protected ILocalizationManager LocalizationManager { get; private set; }

        [Inject]
        private void Construct(T viewModel, ILocalizationManager localizationManager)
        {
            ViewModel = viewModel;
            LocalizationManager = localizationManager;
        }

        private void Awake()
        {
            Debug.LogWarning("awake inherit " + name);
            if (ViewModel == null) throw new NullReferenceException("ViewModel is null. " + name);
            if (LocalizationManager == null) throw new NullReferenceException("LocalizationManager is null. " + name);


            Debug.LogWarning("awake top " + name);
            Template = template.Instantiate();

            if (template == null) throw new NullReferenceException("Template is null. " + name);

            ContentContainer = Template.Q<VisualElement>(UIElementId.MainContentContainerId) ??
                               throw new NullReferenceException(
                                   $"{UIElementId.MainContentContainerId} not found. {name} / {template.name}");

            InitializeView();
            InitializeCallbacks();
            RegisterCallbacks();

            IsInitialized = true;
        }
    }
}
