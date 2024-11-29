using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.UI.Base.Component;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.Components
{
    public sealed class ShelterEnergyTimer : SubViewComponentBase<IGameplayViewModel>
    {
        private VisualElement _timerSlider;
        private Label _timerLabel;

        public ShelterEnergyTimer(IGameplayViewModel viewModel, in VisualElement root,
            in CompositeDisposable disposables)
            : base(viewModel, root, disposables)
        {
        }

        protected override void InitElements()
        {
            _timerSlider = Root.Q<VisualElement>("timer-slider").CheckOnNull();
            _timerLabel = Root.Q<Label>("timer-label").CheckOnNull();
        }

        protected override void Init()
        {
            ViewModel.ShelterEnergyData.Subscribe(UpdateShalterEnergy).AddTo(Disposables);
        }

        private void UpdateShalterEnergy(ShelterEnergyData shelterEnergyData)
        {
            // _timerSlider.style.width = new StyleLength(shelterEnergyData.ShelterEnergy / 10);
            _timerLabel.text = $"{shelterEnergyData.CurrentEnergy} / {shelterEnergyData.MaxEnergy}";
        }
    }
}
