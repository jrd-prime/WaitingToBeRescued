using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Helpers;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.UI
{
    public class MenuButtonsHandler : IMenuButtonsHandler
    {
        private const float DoubleClickDelay = 0.5f;
        private float _lastClickTime;

        private IStateMachine _stateMachine;
        private IUIManager _uiManager;

        [Inject]
        private void Construct(IStateMachine stateMachine, IUIManager uiManager)
        {
            _stateMachine = stateMachine;
            _uiManager = uiManager;
        }

        public void PlayButtonClicked()
        {
            _stateMachine.ChangeStateTo(EGameState.Gameplay);
        }

        public void SettingsButtonClicked()
        {
            _stateMachine.ChangeStateTo(EGameState.Settings);
        }

        public void ExitButtonClicked()
        {
            var currentTime = Time.time;

            if (currentTime - _lastClickTime < DoubleClickDelay)
                App.ExitGame();
            else
                _lastClickTime = currentTime;

            _uiManager.ShowPopUpAsync("Click 2 times to exit.", (int)(DoubleClickDelay * 2000));
        }

        public void MenuButtonClicked()
        {
            _stateMachine.ChangeStateTo(EGameState.Menu);
        }
    }

    public interface IMenuButtonsHandler
    {
        public void PlayButtonClicked();
        public void SettingsButtonClicked();
        public void ExitButtonClicked();
        public void MenuButtonClicked();
    }
}
