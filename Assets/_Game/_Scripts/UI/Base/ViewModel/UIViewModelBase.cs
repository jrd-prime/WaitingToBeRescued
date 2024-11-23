using System;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.ViewModel
{
    public interface IUIViewModel : IInitializable
    {
    }

    public abstract class UIViewModelBase<TModel, TSubStateEnum> : IUIViewModel, IInitializable
        where TSubStateEnum : Enum
        where TModel : IUIModel<TSubStateEnum>
    {
        protected TModel Model { get; private set; }

        [Inject]
        private void Construct(TModel model)
        {
            Model = model;

            if (Model == null) throw new NullReferenceException($"{typeof(TModel)} is null");
        }

        protected readonly CompositeDisposable Disposables = new();

        public abstract void Initialize();
    }
}
