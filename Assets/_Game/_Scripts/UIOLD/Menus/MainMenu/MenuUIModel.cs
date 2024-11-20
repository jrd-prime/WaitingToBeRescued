using _Game._Scripts.UI.Base.Model;
using UnityEditor;
using UnityEngine;

namespace _Game._Scripts.UIOLD.Menus.MainMenu
{
    public interface IMenuUIModel : IUIModel
    {
        public void StartButtonClicked();
        public void SettingsButtonClicked();
        public void ExitButtonClicked();
    }

    public class MenuUIModel : UIModelBase, IMenuUIModel
    {
        private const float DoubleClickDelay = 0.5f;
        private float _lastClickTime;

        public void StartButtonClicked()
        {
            StateMachine.ChangeStateTo(GameStateType.Gameplay);
        }

        public void SettingsButtonClicked()
        {
            StateMachine.ChangeStateTo(GameStateType.Settings);
        }

        public void ExitButtonClicked()
        {
            var currentTime = Time.time;

            if (currentTime - _lastClickTime < DoubleClickDelay)
                ExitGame();
            else
                _lastClickTime = currentTime;

            UIManager.ShowPopUpAsync("Click 2 times to exit.", (int)(DoubleClickDelay * 2000));
        }

        private static void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        public override void Initialize()
        {
            
        }
    }
}
