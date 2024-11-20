using System;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.GameStateMachine.State;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.JCamera;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.Player;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UIOLD.MovementControl;
using _Game._Scripts.UIOLD.MovementControl.FullScreen;
using _Game._Scripts.UIOLD.PopUpText;
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

            builder.RegisterComponent(uiManager).As<IUIManager>();
            // MonoBehaviour
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


            // State machine
            builder.Register<StateMachine>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GameStateBase>(Lifetime.Singleton).AsSelf();

            builder.Register<MenuState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GamePlayState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<SettingsState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<PauseState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }
    }
}
