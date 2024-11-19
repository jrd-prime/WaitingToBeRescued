using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.UI;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.NewUI.Menus.Main
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] public GameStateType viewForGameStateType = GameStateType.NotSet;

        [RequiredField, SerializeField] protected VisualTreeAsset viewTemplate;
        private TemplateContainer _template;

        private const string MainContentContainerId = "main-content-container";
        private bool _isInitialized;
        protected VisualElement _contentContainer;
        protected ILocalizationSystem _localizationSystem;

        protected readonly Dictionary<Button, EventCallback<ClickEvent>> CallbacksCache = new();

        [Inject]
        private void Construct(ILocalizationSystem localizationSystem)
        {
            Debug.LogWarning("construct ViewBase " + localizationSystem);
            _localizationSystem = localizationSystem;
        }

        private void Start()
        {
            Debug.Log("Awake ViewBase");
            if (viewForGameStateType == GameStateType.NotSet)
                throw new Exception("GameStateType for view is not set. " + name);
            if (viewTemplate == null) throw new NullReferenceException("ViewTemplate is null. " + name);
            _template = viewTemplate.Instantiate();

            if (_template == null) throw new NullReferenceException("Template is null. " + name);
            _contentContainer = _template.Q<VisualElement>(MainContentContainerId) ??
                                throw new NullReferenceException($"{MainContentContainerId} not found");
            InitializeView();
            InitializeCallbacks();
            RegisterCallbacks();

            _isInitialized = true;
        }

        protected abstract void InitializeCallbacks();

        protected abstract void RegisterCallbacks();


        protected abstract void InitializeView();

        public TemplateContainer GetTemplateContainer()
        {
            if (!_isInitialized)
                throw new Exception("View is not initialized. " + name); //TODO mb call InitializeView??
            return _template;
        }
    }

    [Serializable]
    public struct ButtonData
    {
        public string buttonNameId;
        public ButtonActionData buttonActionData;
    }

    public enum ButtonActionData
    {
        Play,
        Settings,
        Exit
    }

    public abstract class CustomMenuView<T> : ViewBase where T : IUINewViewModel
    {
        [SerializeField] protected string headerNameId;
        [SerializeField] protected ButtonData[] buttons;
        protected T ViewModel { get; private set; }


        [Inject]
        private void Construct(T viewModel)
        {
            Debug.Log("CustomView Construct " + name);
            ViewModel = viewModel;
        }
    }
}
