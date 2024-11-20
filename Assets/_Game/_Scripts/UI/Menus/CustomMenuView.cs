using System;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.UI.Base.View;
using _Game._Scripts.UI.Base.ViewModel;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.UI.Menus
{
    public abstract class CustomMenuView<T> : ViewBase where T : IUIViewModel
    {
        [RequiredField, SerializeField] protected string headerNameId;
        protected T ViewModel { get; private set; }

        [Inject]
        private void Construct(T viewModel)
        {
            ViewModel = viewModel;
        }

        private void Awake()
        {
            if (headerNameId == null) throw new NullReferenceException("HeaderNameId is null.");
        }
    }
}
