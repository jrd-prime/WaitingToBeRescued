using System;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.GameStates.Gameplay.UI.Components;
using _Game._Scripts.UI.Base.View;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI
{
    public class GameplayView : CustomUIViewBase<IGameplayViewModel, EGameplaySubState>
    {
        private Button _menuButton;

        private HealthBar _healthBarComponent;
        private ExperienceBar _experienceBarComponent;
        private Movement _movementComponent;

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
