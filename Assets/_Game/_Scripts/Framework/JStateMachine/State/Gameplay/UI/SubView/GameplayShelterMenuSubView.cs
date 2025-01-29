using System;
using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI.Base;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI.Components;
using _Game._Scripts.UI.Base.View;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI.SubView
{
    public class GameplayShelterMenuSubView : CustomSubViewBase<IGameplayViewModel>
    {
        private Button _closeBtn;

        private HealthBar _healthBarComponent;
        private ExperienceBar _experienceBarComponent;

        protected override void InitializeView()
        {
            _closeBtn = ContentContainer.Q<Button>(UIElementId.CloseBtnIDName).CheckOnNull();
        }

        protected override void CreateAndInitComponents()
        {
            if (ViewModel == null)
                throw new NullReferenceException("ViewModel is null");
        }

        protected override void Localize()
        {
        }

        protected override void InitializeCallbacks()
        {
            CallbacksCache.TryAdd(_closeBtn, _ => ViewModel.CloseBtnClicked.OnNext(Unit.Default));
        }
    }
}
