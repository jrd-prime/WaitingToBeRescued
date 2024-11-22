using System;
using _Game._Scripts.UI.Base.Model;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.UI.Base.ViewModel
{
    public abstract class CustomUIViewModel<TModel, TSubStateEnum> : UIViewModelBase
        where TModel : class, IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
        protected TModel Model { get; private set; }

        [Inject]
        private void Construct(TModel model)
        {
            Model = model;

            Debug.LogWarning("model " + model);

            if (Model == null) throw new NullReferenceException($"{typeof(TModel)} is null");
        }
    }
}
