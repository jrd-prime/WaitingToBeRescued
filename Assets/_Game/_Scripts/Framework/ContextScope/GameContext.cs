using System;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.GameStateMachine.State.Gameover;
using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.Framework.GameStateMachine.State.Pause;
using _Game._Scripts.Framework.GameStateMachine.State.Win;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.JCamera;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.Player;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.Gameplay;
using _Game._Scripts.UI.Menu;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UI.MovementControl;
using _Game._Scripts.UI.MovementControl.FullScreen;
using _Game._Scripts.UI.PopUpText;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class GameContext : LifetimeScope
    {
        [RequiredField, SerializeField] private CameraManagerBase cameraManager;
        [RequiredField, SerializeField] private GameManager gameManager;
        [RequiredField, SerializeField] private PopUpTextManager popUpTextManager;

        [FormerlySerializedAs("uiController")] [RequiredField, SerializeField]
        private UIManagerBase uiManager;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>Game context</color>");

            if (uiManager == null) throw new NullReferenceException("UIController is null");

            builder.RegisterComponent(uiManager).As<IUIManager>().As<IInitializable>();
            builder.RegisterComponent(cameraManager).As<ICameraManager>().As<IInitializable>();


            builder.Register<IPlayerModel, PlayerModel>(Lifetime.Singleton).As<IInitializable, IDisposable>();
            builder.Register<IPlayerViewModel, PlayerViewModel>(Lifetime.Singleton);

            builder.Register<FullScreenMovementModel>(Lifetime.Singleton)
                .As<IFullScreenMovementModel, IMovementControlModel>();
            builder.Register<FullScreenMovementViewModel>(Lifetime.Singleton)
                .As<IFullScreenMovementViewModel, IMovementControlViewModel>();

            builder.Register<CameraFollowSystem>(Lifetime.Singleton);


            builder.RegisterComponent(gameManager).AsSelf().AsImplementedInterfaces();
            builder.RegisterComponent(popUpTextManager).AsSelf().AsImplementedInterfaces();

            // Menu buttons handler
            builder.Register<IMenuButtonsHandler, MenuButtonsHandler>(Lifetime.Singleton);

            // Main menu
            builder.Register<IMenuViewModel, MenuViewModel>(Lifetime.Singleton).As<IInitializable>();
            // Gameplay UI
            builder.Register<IGameplayViewModel, GameplayViewModel>(Lifetime.Singleton).As<IInitializable>();
            // State models
            builder.Register<IMenuModel, MenuModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IGameplayModel, GameplayModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IGameoverModel, GameoverModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IPauseModel, PauseModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IWinModel, WinModel>(Lifetime.Singleton).As<IInitializable>();


            // State machine
            builder.Register<IStateMachine, StateMachine>(Lifetime.Singleton).As<IPostStartable>();

            builder.Register<MenuState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GamePlayState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GameOverState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<PauseState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<WinState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }
    }
}
