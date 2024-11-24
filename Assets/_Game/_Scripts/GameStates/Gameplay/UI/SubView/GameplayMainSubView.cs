using _Game._Scripts.UI.Base.View;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.GameStates.Gameplay.UI.SubView
{
    public class GameplayMainSubView : CustomSubViewBase<IGameplayViewModel>
    {
        private Button _menuBtn;

        protected override void InitializeView()
        {
            _menuBtn = ContentContainer.Q<Button>("menu-btn");
        }

        protected override void Localize()
        {
        }

        protected override void InitializeCallbacks()
        {
            CallbacksCache.TryAdd(_menuBtn, _ => ViewModel.MenuButtonClicked.OnNext(Unit.Default));
        }
    }
}
