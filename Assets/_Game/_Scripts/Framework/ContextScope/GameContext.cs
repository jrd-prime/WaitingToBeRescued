using System;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.GameStateMachine.State;
using _Game._Scripts.Framework.GameStateMachine.State.Gameover;
using _Game._Scripts.Framework.GameStateMachine.State.Gameplay;
using _Game._Scripts.Framework.GameStateMachine.State.Menu;
using _Game._Scripts.Framework.GameStateMachine.State.Menu.SubState;
using _Game._Scripts.Framework.GameStateMachine.State.Pause;
using _Game._Scripts.Framework.GameStateMachine.State.Win;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.JCamera;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.Player;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI.Gameplay;
using _Game._Scripts.UI.Menu;
using _Game._Scripts.UI.Menu.Base;
using _Game._Scripts.UIOLD;
using _Game._Scripts.UIOLD.MovementControl;
using _Game._Scripts.UIOLD.MovementControl.FullScreen;
using _Game._Scripts.UIOLD.PopUpText;
using R3;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;
using GameplaySubStateType = _Game._Scripts.UI.Gameplay.GameplaySubStateType;

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

            builder.RegisterComponent(uiManager).As<IUIManager>();
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

            // State models
            builder.Register<IMenuModel<MenuSubStateType>, MenuModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IGameplayModel<GameplaySubStateType>, GameplayModel>(Lifetime.Singleton)
                .As<IInitializable>();
            builder.Register<IGameoverModel<GameoverSubStateType>, GameoverModel>(Lifetime.Singleton)
                .As<IInitializable>();
            builder.Register<IPauseModel<PauseSubStateType>, PauseModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IWinModel<WinSubStateType>, WinModel>(Lifetime.Singleton).As<IInitializable>();


            // State machine
            builder.Register<StateMachine>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<MenuState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GamePlayState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GameOverState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<PauseState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<WinState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }
    }

    public class GameoverModel : IGameoverModel<GameoverSubStateType>
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public ReactiveProperty<GameoverSubStateType> CurrentSubState { get; }
        public ReactiveProperty<GameStateType> GameState { get; }
    }

    public class PauseModel : IPauseModel<PauseSubStateType>
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public ReactiveProperty<PauseSubStateType> CurrentSubState { get; }
        public ReactiveProperty<GameStateType> GameState { get; }
    }

    public class WinModel : IWinModel<WinSubStateType>
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public ReactiveProperty<WinSubStateType> CurrentSubState { get; }
        public ReactiveProperty<GameStateType> GameState { get; }
    }
}
