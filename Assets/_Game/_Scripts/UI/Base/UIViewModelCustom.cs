using System;
using _Game._Scripts.UI.Interfaces;
using VContainer;

namespace _Game._Scripts.UI.Base
{
    public abstract class UIViewModelCustom<T> : UIViewModelBase where T : class, IUIModel
    {
        protected static T Model { get; private set; }

        [Inject]
        private void Construct(T model)
        {
            Model = model;

            if (Model == null) throw new NullReferenceException($"{typeof(T)} is null");
        }
    }
}
