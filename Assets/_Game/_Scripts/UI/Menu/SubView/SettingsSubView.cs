using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.UI.Base.View;
using _Game._Scripts.UI.Base.ViewModel;
using _Game._Scripts.UI.Menu.Base;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Menu.SubView
{
    public class SettingsSubView : CustomSubViewBase<IMenuViewModel>
    {
        private Button _backBtn;
        private VisualElement _content;

        protected override void InitializeView()
        {
            _content = ContentContainer.Q<VisualElement>(UIElementId.MenuContentId).CheckOnNull();
            _backBtn = _content.Q<Button>(UIElementId.BackBtnId).CheckOnNull();
        }

        protected override void Localize()
        {
        }

        protected override void InitializeCallbacks()
        {
            CallbacksCache.Add(_backBtn, _ => ViewModel.BackButtonClicked.OnNext(Unit.Default));
        }
    }
}
