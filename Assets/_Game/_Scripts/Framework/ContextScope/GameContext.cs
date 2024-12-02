﻿using System;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.JrdStateMachine;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.JCamera;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.DayTimer;
using _Game._Scripts.Framework.Manager.Shelter.Energy;
using _Game._Scripts.Framework.Manager.Shelter.Temperature;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.Framework.MovementControl;
using _Game._Scripts.Framework.MovementControl.FullScreen;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.GameStates.Gameover;
using _Game._Scripts.GameStates.Gameplay.State;
using _Game._Scripts.GameStates.Gameplay.UI;
using _Game._Scripts.GameStates.Gameplay.UI.Base;
using _Game._Scripts.GameStates.Menu.State;
using _Game._Scripts.GameStates.Menu.UI;
using _Game._Scripts.GameStates.Menu.UI.Base;
using _Game._Scripts.GameStates.Pause;
using _Game._Scripts.GameStates.Win;
using _Game._Scripts.Interactable;
using _Game._Scripts.Player;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI.Base.Model;
using _Game._Scripts.UI.GameOver;
using _Game._Scripts.UI.Pause;
using _Game._Scripts.UI.PopUpText;
using _Game._Scripts.UI.Win;
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


            builder.Register<DayTimerDataModel>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();


            builder.RegisterComponent(uiManager).As<IUIManager>().As<IInitializable>();
            builder.RegisterComponent(cameraManager).As<ICameraManager>().As<IInitializable>();


            builder.Register<IPlayerModel, PlayerModel>(Lifetime.Singleton).As<IInitializable, IDisposable>();
            builder.Register<IPlayerViewModel, PlayerViewModel>(Lifetime.Singleton).As<IDisposable>();

            builder.Register<FullScreenMovementModel>(Lifetime.Singleton)
                .As<IMovementControlModel, IInitializable, IDisposable>();
            builder.Register<FullScreenMovementViewModel>(Lifetime.Singleton)
                .As<IMovementControlViewModel, IDisposable>();

            builder.Register<CameraFollowSystem>(Lifetime.Singleton);


            builder.RegisterComponent(gameManager).AsSelf().AsImplementedInterfaces();
            builder.RegisterComponent(popUpTextManager).AsSelf().AsImplementedInterfaces();


            // Main menu
            builder.Register<IMenuViewModel, MenuViewModel>(Lifetime.Singleton).As<IInitializable, IDisposable>();
            // Gameplay UI
            builder.Register<IGameplayViewModel, GameplayViewModel>(Lifetime.Singleton)
                .As<IInitializable, IDisposable>();
            // State models
            builder.Register<IMenuModel, MenuModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IGameplayModel, GameplayModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IGameoverModel, GameoverModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IPauseModel, PauseModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IWinModel, WinModel>(Lifetime.Singleton).As<IInitializable>();


            // State machine
            builder.Register<IStateMachine, StateMachine>(Lifetime.Singleton).As<IStartable>();

            builder.Register<MenuState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GamePlayState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GameOverState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<PauseState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<WinState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();


            builder.Register<ShelterModel>(Lifetime.Singleton).AsSelf().As<IInteractableModel, IInitializable>();

            builder.Register<IStateMachineReactiveAdapter, StateMachineReactiveAdapter>(Lifetime.Singleton);


            builder.Register<EnergyDataModel>(Lifetime.Singleton).AsSelf().As<IInitializable>();
            builder.Register<AmbientTemperatureDataModel>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<GameCountdownsController>(Lifetime.Singleton)
                .As<IGameCountdownsController, IInitializable, IDisposable>();
        }
    }
}
