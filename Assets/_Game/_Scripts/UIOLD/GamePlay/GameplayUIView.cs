using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.UIOLD.Base;
using _Game._Scripts.UIOLD.GamePlay.Components;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UIOLD.GamePlay
{
    public class GameplayUIView : UIView<GameplayUIViewModel>
    {
        private static readonly Vector2 ScreenTargetSize = new(800f, 360f);
        private const float Offset = 16f;

        private Button _menuButton;

        private HealthBar _healthBarComponent;
        private ExperienceBar _experienceBarComponent;
        private Movement _movementComponent;

        protected override void InitElements()
        {
            Debug.LogWarning("init elements " + name);
            if (ViewModel == null) throw new NullReferenceException($"ViewModel is null");
            {
            }

            var safeZoneOffset = ScreenHelper.GetSafeZoneOffset(ScreenTargetSize.x, ScreenTargetSize.y);
            RootVisualElement.style.marginLeft = safeZoneOffset.x >= Offset ? safeZoneOffset.x : Offset;
            RootVisualElement.style.marginTop = safeZoneOffset.y;

            // Health bar
            _healthBarComponent = new HealthBar(in ViewModel, in RootVisualElement, in Disposables);
            _healthBarComponent.InitElements();
            // Experience bar
            _experienceBarComponent = new ExperienceBar(in ViewModel, in RootVisualElement, in Disposables);
            _experienceBarComponent.InitElements();
            // Movement
            _movementComponent = new Movement(in ViewModel, in RootVisualElement, in Disposables);
            _movementComponent.InitElements();

            _menuButton = RootVisualElement.Q<Button>(UIConst.MenuButtonIDName);
            CheckOnNull(_menuButton, UIConst.MenuButtonIDName, name);
        }

        protected override void Init()
        {
            _healthBarComponent.Init();
            _experienceBarComponent.Init();
            _movementComponent.Init();

            ViewModel.PlayerHealth.Subscribe(SetHealth).AddTo(Disposables);
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

        protected override void InitCallbacksCache()
        {
            CallbacksCache.Add(_menuButton, _ => ViewModel.MenuButtonClicked.OnNext(Unit.Default));
        }
    }
}
