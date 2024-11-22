using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.UI.Base.View;
using _Game._Scripts.UI.Base.ViewModel;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.UI.Menu.Base
{
    public abstract class CustomMenuView<TViewModel, TSubStateEnum> : ViewBase
        where TViewModel : IUIViewModel
        where TSubStateEnum : Enum
    {
        [RequiredField, SerializeField] protected string headerNameId;
        protected TViewModel ViewModel { get; private set; }
        protected TSubStateEnum SubStateType { get; private set; }

        [SerializeField] protected List<SubStateData<TSubStateEnum>> subStatesData = new();

        [Inject]
        private void Construct(TViewModel viewModel) => ViewModel = viewModel;


        private void Awake()
        {
            if (headerNameId == null) throw new NullReferenceException("HeaderNameId is null.");
        }
    }

    [Serializable]
    public struct SubStateData<TSubStateEnum> where TSubStateEnum : Enum
    {
        public string headerNameId;
        public TSubStateEnum subStateType;
        public VisualTreeAsset visualTreeAsset;
    }
}
