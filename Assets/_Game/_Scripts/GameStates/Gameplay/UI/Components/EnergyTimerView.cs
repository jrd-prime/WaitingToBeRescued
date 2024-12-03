using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using R3;
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
        private float _currentEnergyBarWidth;
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
            ViewModel.EnergyMax.Subscribe(x =>
            {
                // Debug.LogWarning("Set energy max to " + x);
                _energyInitial = x;
            }).AddTo(Disposables);
            // ViewModel.RemainingTime.Subscribe(x => _countDown.text = x).AddTo(Disposables);
            // ViewModel.Day.Subscribe(x => _day.text = x.ToString()).AddTo(Disposables);

            ViewModel.EnergyBarWidthPercent.Subscribe(UpdateEnergyBar).AddTo(Disposables);
            ViewModel.EnergyValueFormatted.Subscribe(UpdateEnergyText).AddTo(Disposables);
        }

        private void InitEnergyBar(float width)
        {
            if (_isFullEnergyBarWidthSet) return;
            _isFullEnergyBarWidthSet = true;
            _fullEnergyWidth = width;
            _currentEnergyBarWidth = _fullEnergyWidth;
            _energyCountdownBarTween = new JTweenAnim(in _energyBar, width, AnimationDuration);

            UpdateEnergyBar(1);
            _energyBar.UnregisterCallback(_energyBarCallback);
        }

        private void UpdateEnergyText(string value)
        {
            _energyLabel.text = value;
        }

        private void UpdateEnergyBar(float value)
        {
            if (!_isFullEnergyBarWidthSet) return;
            _energyCountdownBarTween.RunTween(value);
        }
    }
}
