using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.NewUI;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.GameStateMachine
{
    public class GameStateBase : IInitializable
    {
        protected GameManager GameManager { get; private set; }
        protected IUIManager UIController { get; private set; }
        protected IPlayerModel PlayerModel { get; private set; }

        [Inject]
        private void Construct(GameManager gameManager,
            IUIManager uiController,
            IPlayerModel playerModel)
        {
            GameManager = gameManager;
            UIController = uiController;
            PlayerModel = playerModel;
        }

        public void Initialize()
        {
            Assert.IsNotNull(GameManager, $"Game manager is null. {this}");
            // Assert.IsNotNull(UIManager, $"UI manager is null. {this}");
        }
    }
}
