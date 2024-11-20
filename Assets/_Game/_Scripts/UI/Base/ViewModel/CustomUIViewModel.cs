using System;
using _Game._Scripts.UI.Base.Model;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.UI.Base.ViewModel
{
    public abstract class CustomUIViewModel<T> : UIViewModelBase where T : class, IUIModel
    {
        protected T Model { get; private set; }

        [Inject]
        private void Construct(T model)
        {
            Model = model;

            Debug.LogWarning("model " + model);

            if (Model == null) throw new NullReferenceException($"{typeof(T)} is null");
        }
    }
}
