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
        private ShelterEnergyTimer _shelterEnergyTimer;
        private AmbientTemperatureTimer _ambientTemperatureTimer;

        protected override void InitializeView()
        {
            _menuBtn = ContentContainer.Q<Button>("menu-btn").CheckOnNull();
        }

        protected override void CreateAndInitComponents()
        {
            if (ViewModel == null) throw new NullReferenceException("ViewModel is null");

            _movementComponent = new Movement(ViewModel, ContentContainer, Disposables);
            _shelterEnergyTimer = new ShelterEnergyTimer(ViewModel, ContentContainer, Disposables);
            _ambientTemperatureTimer = new AmbientTemperatureTimer(ViewModel, ContentContainer, Disposables);
        }

        protected override void Localize()
        {
        }

        protected override void InitializeCallbacks()
        {
            CallbacksCache.TryAdd(_menuBtn, _ => ViewModel.MenuBtnClicked.OnNext(Unit.Default));
        }
    }
}
