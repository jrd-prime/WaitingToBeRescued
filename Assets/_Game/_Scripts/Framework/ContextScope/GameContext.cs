using System;
using _Game._Scripts.Framework.GameStateMachine;
using _Game._Scripts.Framework.GameStateMachine.State;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Attributes;
using _Game._Scripts.Framework.Managers.Game;
using _Game._Scripts.Framework.Managers.JCamera;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.NewUI;
using _Game._Scripts.Player;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI.MovementControl;
using _Game._Scripts.UI.MovementControl.FullScreen;
using _Game._Scripts.UI.PopUpText;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using IMovementControlModel = _Game._Scripts.UI.MovementControl.IMovementControlModel;

namespace _Game._Scripts.Framework.ContextScope
{
    public class GameContext : LifetimeScope
    {
        [RequiredField, SerializeField] private CameraManagerBase cameraManager;
        [RequiredField, SerializeField] private GameManager gameManager;
        [RequiredField, SerializeField] private PopUpTextManager popUpTextManager;

        [RequiredField, SerializeField] private UIControllerBase uiController;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>Game context</color>");


            if (uiController == null) throw new NullReferenceException("UIController is null");

            builder.RegisterComponent(uiController).As<IUIController>();
            // MonoBehaviour
            builder.RegisterComponent(cameraManager).As<ICameraManager>().As<IInitializable>();


            builder.Register<IPlayerModel, PlayerModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IPlayerViewModel, PlayerViewModel>(Lifetime.Singleton);

            builder.Register<FullScreenMovementModel>(Lifetime.Singleton).As<IFullScreenMovementModel>()
                .As<IMovementControlModel>();
            builder.Register<FullScreenMovementViewModel>(Lifetime.Singleton).As<IFullScreenMovementViewModel>()
                .As<IMovementControlViewModel>();

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
