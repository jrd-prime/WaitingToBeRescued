using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class AmbientTempTimerView : SubViewComponentBase<IGameplayViewModel>
    {
        private VisualElement _movementRoot;
        private Label _currentTemp;
        private Label _nextDrop;

        public AmbientTempTimerView(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _currentTemp = Root.Q<Label>("cur-label").CheckOnNull();
            _nextDrop = Root.Q<Label>("next-down-label").CheckOnNull();
        }

        protected override void Init()
        {
            ViewModel.AmbientTemperatureData.Subscribe(UpdateTemperatureData).AddTo(Disposables);
       
        }

        private void UpdateTemperatureData(AmbientTempData ambientTemperatureData)
        {
            Debug.LogWarning("update temp");
            var temp = ambientTemperatureData.Current;
            var curr = temp switch
            {
                > 0 => $"+{temp}",
                < 0 => $"{temp}",
                _ => $"{temp}"
            };

            _currentTemp.text = curr;
            _nextDrop.text = ambientTemperatureData.NextChange.ToString();
        }
    }
}
