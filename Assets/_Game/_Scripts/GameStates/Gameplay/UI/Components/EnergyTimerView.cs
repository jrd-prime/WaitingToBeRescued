using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.Shelter;
using _Game._Scripts.Framework.Shelter.Energy;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class EnergyTimerView : SubViewComponentBase<IGameplayViewModel>
    {
        private const float AnimationDuration = .8f;
        private VisualElement _energyBar;
        private Label _energyLabel;
        private bool _isFullEnergyBarWidthSet;
        private float _fullEnergyWidth;
        private float _pxPerPointEnergy;
        private float _energyInitial;

        private EventCallback<GeometryChangedEvent> _energyBarCallback;

        private JTweenAnim _energyCountdownBarTween;

        public EnergyTimerView(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _energyBarCallback = _ => InitEnergyBar(_energyBar.resolvedStyle.width);

            _energyBar = Root.Q<VisualElement>("timer-slider").CheckOnNull();
            _energyLabel = Root.Q<Label>("timer-label").CheckOnNull();
            _energyBar.RegisterCallback(_energyBarCallback);
        }

        protected override void Init()
        {
            ViewModel.PreparedEnergyData.Subscribe(UpdateEnergyBar).AddTo(Disposables);
        }

        private void InitEnergyBar(float width)
        {
            if (_isFullEnergyBarWidthSet) return;
            _isFullEnergyBarWidthSet = true;
            _fullEnergyWidth = width;
            _energyCountdownBarTween = new JTweenAnim(_energyBar, width, AnimationDuration);

            _energyBar.UnregisterCallback(_energyBarCallback);
            UpdateEnergyBar(ViewModel.PreparedEnergyData.CurrentValue);
        }

        private void UpdateEnergyBar(PreparedEnergyData data)
        {
            _energyLabel.text = data.EnergyValueFormatted;

            if (!_isFullEnergyBarWidthSet) return;
            _energyCountdownBarTween.RunTween(data.EnergyBarWidthPercent);
        }
    }
}
