using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.Localization;
using _Game._Scripts.UIOLD;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class ViewBase : MonoBehaviour, IUIView
    {
        [SerializeField] public GameStateType viewForGameStateType = GameStateType.NotSet;
        [RequiredField, SerializeField] protected VisualTreeAsset viewTemplate;
        [SerializeField] public bool safeZone;

        protected VisualElement ContentContainer;
        protected ILocalizationManager LocalizationManager;

        private TemplateContainer _template;
        private bool _isInitialized;

        protected readonly CompositeDisposable Disposables = new();

        protected readonly Dictionary<Button, EventCallback<ClickEvent>> CallbacksCache = new();

        [Inject]
        private void Construct(ILocalizationManager localizationManager)
        {
            LocalizationManager = localizationManager;
        }

        private void Start()
        {
            if (viewForGameStateType == GameStateType.NotSet)
                throw new Exception("GameStateType for view is not set. " + name);

            if (viewTemplate == null) throw new NullReferenceException("ViewTemplate is null. " + name);
            _template = viewTemplate.Instantiate();

            if (_template == null) throw new NullReferenceException("Template is null. " + name);
            ContentContainer = _template.Q<VisualElement>(UIElementId.MainContentContainerId) ??
                               throw new NullReferenceException($"{UIElementId.MainContentContainerId} not found. {name}");

            if (LocalizationManager == null) throw new NullReferenceException("LocalizationManager is null. " + name);

            InitializeView();
            InitializeCallbacks();
            RegisterCallbacks();

            _isInitialized = true;
        }

        protected abstract void InitializeView();
        protected abstract void InitializeCallbacks();

        private void RegisterCallbacks()
        {
            Debug.Log("reg callbacks " + name);
            foreach (var callback in CallbacksCache)
                callback.Key.RegisterCallback(callback.Value);
        }

        private void UnregisterCallbacks()
        {
            Debug.Log("unreg callbacks " + name);
            foreach (var callback in CallbacksCache)
                callback.Key.UnregisterCallback(callback.Value);
        }

        public TemplateContainer GetTemplateContainer()
        {
            if (!_isInitialized)
                throw new Exception("View is not initialized. " + name); //TODO mb call InitializeView??
            return _template;
        }
    }
}
