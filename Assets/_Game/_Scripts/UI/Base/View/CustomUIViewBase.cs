using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.Localization;
using _Game._Scripts.UI.Base.ViewModel;
using _Game._Scripts.UI.Menu.Base;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class CustomUIViewBase<TViewModel, TSubStateEnum> : UIViewBase
        where TViewModel : IUIViewModel
        where TSubStateEnum : Enum
    {
        protected TViewModel ViewModel { get; private set; }
        protected TSubStateEnum SubStateType { get; private set; }

        protected ILocalizationManager LocalizationManager;
        [SerializeField] protected List<SubStateData<TSubStateEnum>> subStatesData = new();


        [Inject]
        private void Construct(TViewModel viewModel, ILocalizationManager localizationManager)
        {
            ViewModel = viewModel;
            LocalizationManager = localizationManager;
        }

        private void Start()
        {
            if (viewForEGameState == EGameState.NotSet)
                throw new Exception("GameStateType for view is not set. " + name);

            if (viewTemplate == null) throw new NullReferenceException("ViewTemplate is null. " + name);
            _template = viewTemplate.Instantiate();

            if (_template == null) throw new NullReferenceException("Template is null. " + name);
            ContentContainer = _template.Q<VisualElement>(UIElementId.MainContentContainerId) ??
                               throw new NullReferenceException(
                                   $"{UIElementId.MainContentContainerId} not found. {name}");

            if (LocalizationManager == null) throw new NullReferenceException("LocalizationManager is null. " + name);

            InitializeView();
            InitializeCallbacks();
            RegisterCallbacks();

            _isInitialized = true;
        }


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
    }
}
