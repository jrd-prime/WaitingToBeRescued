using _Game._Scripts.Framework.Data.Constants;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.NewUI.Menus.Main
{
    public class MainMenuMenuView : CustomMenuView<IMainMenu_ViewModel>
    {
        private Button _playBtn;
        private Button _settingsBtn;
        private Button _exitBtn;

        protected override void InitializeCallbacks()
        {
            CallbacksCache.Add(_playBtn, _ => ViewModel.PlayButtonClicked.OnNext(Unit.Default));
            CallbacksCache.Add(_settingsBtn, _ => ViewModel.SettingsButtonClicked.OnNext(Unit.Default));
            CallbacksCache.Add(_exitBtn, _ => ViewModel.ExitButtonClicked.OnNext(Unit.Default));
        }

        protected override void RegisterCallbacks()
        {
        }

        protected override void InitializeView()
        {
            var head = _contentContainer.Q<Label>("header");
            var content = _contentContainer.Q<VisualElement>("menu-content");

            _playBtn = content.Q<Button>("play-btn");
            _settingsBtn = content.Q<Button>("settings-btn");
            _exitBtn = content.Q<Button>("exit-btn");

            head.text = _localizationSystem.GetString(headerNameId).ToUpper();

            _playBtn.text = _localizationSystem.GetString(NameId.playBtnNameId).ToUpper();
            _settingsBtn.text = _localizationSystem.GetString(NameId.settingsBtnNameId).ToUpper();
            _exitBtn.text = _localizationSystem.GetString(NameId.exitBtnNameId).ToUpper();
        }
    }
}
