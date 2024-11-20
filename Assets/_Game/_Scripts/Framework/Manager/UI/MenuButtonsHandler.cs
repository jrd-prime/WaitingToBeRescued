using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.UIOLD;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.UI
{
    public class MenuButtonsHandler : IMenuButtonsHandler
    {
        private const float DoubleClickDelay = 0.5f;
        private float _lastClickTime;
        
        private StateMachine _stateMachine;
        private IUIManager _uiManager;

        [Inject]
        private void Construct(StateMachine stateMachine, IUIManager uiManager)
        {
            _stateMachine = stateMachine;
            _uiManager = uiManager;
        }

        public void PlayButtonClicked()
        {
            _stateMachine.ChangeStateTo(GameStateType.Gameplay);
        }

        public void SettingsButtonClicked()
        {
            _stateMachine.ChangeStateTo(GameStateType.Settings);
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
    }

    public interface IMenuButtonsHandler
    {
        public void PlayButtonClicked();
        public void SettingsButtonClicked();
        public void ExitButtonClicked();
    }
}
