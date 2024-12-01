using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.GameStates.Gameplay.UI.Components;
using _Game._Scripts.UI.Base.View;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.SubView
{
    public class GameplayMainSubView : CustomSubViewBase<IGameplayViewModel>
    {
        private Button _menuBtn;

        private HealthBar _healthBarComponent;
        private ExperienceBar _experienceBarComponent;
        private Movement _movementComponent;
        private EnergyTimerView _energyTimerView;
        private AmbientTempTimerView _ambientTempTimerView;
        private Button _addEnergyBtn;
        private DayCountdownTimerView _dayCountdownTimerView;

        protected override void InitializeView()
        {
            _menuBtn = ContentContainer.Q<Button>("menu-btn").CheckOnNull();
            _addEnergyBtn = ContentContainer.Q<Button>("add-energy-btn").CheckOnNull();
        }

        protected override void CreateAndInitComponents()
        {
            if (ViewModel == null) throw new NullReferenceException("ViewModel is null");

            _movementComponent = new Movement(ViewModel, ContentContainer, Disposables);
            _energyTimerView = new EnergyTimerView(ViewModel, ContentContainer, Disposables);
            _ambientTempTimerView = new AmbientTempTimerView(ViewModel, ContentContainer, Disposables);
            _dayCountdownTimerView = new DayCountdownTimerView(ViewModel, ContentContainer, Disposables);
        }

        protected override void Localize()
        {
        }

        protected override void InitializeCallbacks()
        {
            CallbacksCache.TryAdd(_menuBtn, _ => ViewModel.MenuBtnClicked.OnNext(Unit.Default));
            CallbacksCache.TryAdd(_addEnergyBtn, _ => ViewModel.AddEnergyBtnClicked.OnNext(Unit.Default));
        }
    }
}
