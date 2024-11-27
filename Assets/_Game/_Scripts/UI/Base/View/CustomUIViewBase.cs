using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.Localization;
using _Game._Scripts.UI.Base.ViewModel;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.View
{
    /// <summary>
    /// <remarks>Inherited classes should be added to the autoinject</remarks>
    /// </summary>
    public abstract class CustomUIViewBase<TViewModel, TSubStateEnum> : UIViewBase
        where TViewModel : class, IUIViewModel
        where TSubStateEnum : Enum
    {
        [SerializeField] protected TSubStateEnum defaultSubView;
        private IObjectResolver _resolver;
        protected TViewModel ViewModel { get; private set; }
        protected TSubStateEnum SubStateType { get; private set; }

        protected ILocalizationManager LocalizationManager;
        [SerializeField] protected List<SubViewData<TSubStateEnum>> subViewsData = new();
        protected Dictionary<TSubStateEnum, TemplateContainer> initializedViewsCache = new();

        [Inject]
        private void Construct(IObjectResolver resolver, TViewModel viewModel, ILocalizationManager localizationManager)
        {
            _resolver = resolver;
            ViewModel = viewModel;
            LocalizationManager = localizationManager;
        }

        protected void Awake()
        {
            foreach (var subState in subViewsData)
            {
                _resolver.Inject(subState.subView);
                if (!SubViewsCache.TryAdd(subState.subState, subState.subView))
                    throw new Exception($"Subview with subState \"{subState.subState}\" already added to {name} view");
            }
        }

        protected void Start()
        {
            if (viewForEGameState == EGameState.NotSet)
                throw new Exception("GameStateType for view is not set. " + name);
        }
    }
}
