using System;
using System.Collections.Generic;
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
        where TViewModel : class, IUIViewModel
        where TSubStateEnum : Enum
    {
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

        public override void Initialize()
        {
            Debug.LogWarning("initialize " + name);
            foreach (var subState in subViewsData)
            {
                _resolver.Inject(subState.subView);
                subViewsCache.TryAdd(subState.subStateType, subState.subView);
            }
        }


        private void Start()
        {
            if (viewForEGameState == EGameState.NotSet)
                throw new Exception("GameStateType for view is not set. " + name);
        }
    }
}
