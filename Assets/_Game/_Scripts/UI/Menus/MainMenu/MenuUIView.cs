using _Game._Scripts.UI.Base;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Menus.MainMenu
{
    public class MenuUIView : UIView<MenuUIViewModel>, IMenuUIView
    {
        private Button _startButton;
        private Button _settingsButton;
        private Button _exitButton;

        protected override void Init()
        {
        }

        protected override void InitElements()
        {
            Debug.LogWarning("init elements " + name);
            // _startButton = RootVisualElement.Q<Button>(UIConst.StartButtonIDName);
            // _settingsButton = RootVisualElement.Q<Button>(UIConst.SettingsButtonIDName);
            // _exitButton = RootVisualElement.Q<Button>(UIConst.ExitButtonIDName);
            //
            // CheckOnNull(_startButton, UIConst.StartButtonIDName, name);
            // CheckOnNull(_settingsButton, UIConst.SettingsButtonIDName, name);
            // CheckOnNull(_exitButton, UIConst.ExitButtonIDName, name);
        }

        protected override void InitCallbacksCache()
        {
            // CallbacksCache.Add(_startButton, _ => ViewModel.StartButtonClicked.OnNext(Unit.Default));
            // CallbacksCache.Add(_settingsButton, _ => ViewModel.SettingsButtonClicked.OnNext(Unit.Default));
            // CallbacksCache.Add(_exitButton, _ => ViewModel.ExitButtonClicked.OnNext(Unit.Default));
        }
    }

    public interface IMenuUIView
    {
    }
}
