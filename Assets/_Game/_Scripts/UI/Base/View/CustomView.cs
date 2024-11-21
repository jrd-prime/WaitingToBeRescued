﻿using System;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.UI.Base.View;
using _Game._Scripts.UI.Base.ViewModel;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.UI.Menus
{
    public abstract class CustomView<T> : ViewBase where T : IUIViewModel
    {
        protected T ViewModel { get; private set; }

        [Inject]
        private void Construct(T viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
