using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.UI.Base.View;
using _Game._Scripts.UI.Gameplay.Components;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Gameplay
{
    public class GameplayView : CustomUIViewBase<IGameplayViewModel, EGameplaySubState>
    {
        private static readonly Vector2 ScreenTargetSize = new(800f, 360f);
        private const float Offset = 16f;

        private Button _menuButton;

        private HealthBar _healthBarComponent;
        private ExperienceBar _experienceBarComponent;
        private Movement _movementComponent;


        protected override void InitializeView()
        {
            Debug.LogWarning("init elements " + name);
            if (ViewModel == null) throw new NullReferenceException($"ViewModel is null");

            // Movement
            // _movementComponent = new Movement(ViewModel, in ContentContainer, in Disposables);
            // _movementComponent.InitElements();

            // _movementComponent.Init();

            // ViewModel.PlayerHealth.Subscribe(SetHealth).AddTo(Disposables);

            _menuButton = ContentContainer.Q<Button>(UIConst.MenuButtonIDName);
        }

        protected override void InitializeCallbacks()
        {
            CallbacksCache.Add(_menuButton, _ => ViewModel.MenuButtonClicked.OnNext(Unit.Default));
        }

        private void SetHealth(int health)
        {
            if (health <= 0)
            {
                _healthBarComponent.ResetHealthBar();
                _experienceBarComponent.ResetExperienceBar();
                return;
            }

            _healthBarComponent.UpdateHealthBar(health);
        }
    }
}
