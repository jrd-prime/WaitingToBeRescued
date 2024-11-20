﻿using _Game._Scripts.Framework.Data.Constants;
using _Game._Scripts.UIOLD.Base;
using R3;
using UnityEngine.UIElements;

namespace _Game._Scripts.UIOLD.Menus.Settings
{
    public class SettingsUIView : UIView<SettingsUIViewModel>
    {
        private Button _menuButton;
        private Button _musicButton;
        private Button _vfxButton;

        protected override void Init()
        {
        }

        protected override void InitElements()
        {
            _menuButton = RootVisualElement.Q<Button>(UIConst.MenuButtonIDName);
            _musicButton = RootVisualElement.Q<Button>(UIConst.MusicButtonIDName);
            _vfxButton = RootVisualElement.Q<Button>(UIConst.VfxButtonIDName);

            CheckOnNull(_menuButton, UIConst.MenuButtonIDName, name);
            CheckOnNull(_musicButton, UIConst.MusicButtonIDName, name);
            CheckOnNull(_vfxButton, UIConst.VfxButtonIDName, name);
        }

        protected override void InitCallbacksCache()
        {
            CallbacksCache.Add(_menuButton, _ => ViewModel.MenuButtonClicked.OnNext(Unit.Default));
            CallbacksCache.Add(_musicButton, _ => ViewModel.MusicButtonClicked.OnNext(Unit.Default));
            CallbacksCache.Add(_vfxButton, _ => ViewModel.VfxButtonClicked.OnNext(Unit.Default));
        }
    }
}
