using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Localization;
using _Game._Scripts.UI.Base.ViewModel;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class CustomSubViewBase<T> : JSubViewBase where T : IUIViewModel
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
            if (template == null) throw new NullReferenceException("Template is null. " + name);

            Template = template.Instantiate();

            ContentContainer = Template.Q<VisualElement>(UIElementId.MainContentContainerId).CheckOnNull();

            InitializeView();

            IsInitialized = true;
            Debug.Log($"View {name} is initialized.");
        }

        private void Start()
        {
            if (ViewModel == null) throw new NullReferenceException("ViewModel is null. " + name);
            if (LocalizationManager == null) throw new NullReferenceException("LocalizationManager is null. " + name);

            CreateAndInitComponents();
            Localize();
            InitializeCallbacks();
            RegisterCallbacks();
            Debug.Log($"View {name} is ready.");
        }
    }
}
