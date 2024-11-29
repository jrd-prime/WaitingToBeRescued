using System;
using R3;
using UnityEngine.Assertions;
using VContainer;

namespace _Game._Scripts.UI.Bootstrap
{
    public class LoadingScreenViewModel : ILoadingScreenViewModel
    {
        public ReactiveProperty<string> TitleText => _model.LoadingText;

        private ILoadingScreenModel _model;

        [Inject]
        private void Construct(ILoadingScreenModel loadingScreenModel) => _model = loadingScreenModel;

        public void Initialize()
        {
            Assert.IsNotNull(_model, $"{typeof(ILoadingScreenModel)} is null.");
        }
    }
}
