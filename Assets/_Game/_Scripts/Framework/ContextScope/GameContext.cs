using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.JStateMachine;
using _Game._Scripts.Framework.JStateMachine.State.Gameover;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.State;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI;
using _Game._Scripts.Framework.JStateMachine.State.Gameplay.UI.Base;
using _Game._Scripts.Framework.JStateMachine.State.Menu.State;
using _Game._Scripts.Framework.JStateMachine.State.Menu.UI;
using _Game._Scripts.Framework.JStateMachine.State.Menu.UI.Base;
using _Game._Scripts.Framework.JStateMachine.State.Pause;
using _Game._Scripts.Framework.JStateMachine.State.Win;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.JCamera;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.Framework.MovementControl;
using _Game._Scripts.Framework.MovementControl.FullScreen;
using _Game._Scripts.Framework.PlayerStuff;
using _Game._Scripts.Framework.PlayerStuff._Base;
using _Game._Scripts.Framework.Systems;
using _Game._Scripts.Framework.Tickers;
using _Game._Scripts.Framework.Tickers.DayTimer;
using _Game._Scripts.Framework.Tickers.Energy;
using _Game._Scripts.Framework.Tickers.Temperature;
using _Game._Scripts.Player;
using _Game._Scripts.Player.HUD;
using _Game._Scripts.Shelter;
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
        [RequiredField, SerializeField] private MovementUIController movementController;

        [FormerlySerializedAs("uiController")] [RequiredField, SerializeField]
        private UIManagerBase uiManager;

        [FormerlySerializedAs("characterHUDController")] [RequiredField, SerializeField]
        private CharacterHUDManager characterHUDManager;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>Game context</color>");

            Optional<CameraManagerBase>.Some(cameraManager)
                .Match(
                    component => builder.RegisterComponent(component).As<ICameraManager>().As<IInitializable>(),
                    () => throw new NullReferenceException("CameraManager is null"));

            Optional<GameManager>.Some(gameManager)
                .Match(
                    component => builder.RegisterComponent(component).AsSelf().AsImplementedInterfaces(),
                    () => throw new NullReferenceException("GameManager is null"));

            Optional<PopUpTextManager>.Some(popUpTextManager)
                .Match(
                    component => builder.RegisterComponent(component).AsSelf().AsImplementedInterfaces(),
                    () => throw new NullReferenceException("PopUpTextManager is null"));

            Optional<MovementUIController>.Some(movementController)
                .Match(
                    component => builder.RegisterComponent(component).AsSelf(),
                    () => throw new NullReferenceException("MovementUIController is null"));

            Optional<UIManagerBase>.Some(uiManager)
                .Match(
                    component => builder.RegisterComponent(component).As<IUIManager>().As<IInitializable>(),
                    () => throw new NullReferenceException("UIManager is null"));

            Optional<CharacterHUDManager>.Some(characterHUDManager)
                .Match(
                    component => builder.RegisterComponent(component).AsSelf().AsImplementedInterfaces(),
                    () => throw new NullReferenceException("CharacterHUDManager is null"));


            builder.Register<GameCountdownsController>(Lifetime.Singleton)
                .As<IGameCountdownsController, IInitializable, IDisposable>();
            builder.Register<EnergyDataModel>(Lifetime.Singleton).AsSelf().As<IInitializable>();
            builder.Register<AmbientTempDataModel>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<DayTimerDataModel>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();


            builder.Register<IStuffDataManager, StuffDataManager>(Lifetime.Singleton);

            builder.Register<IPlayerModel, PlayerModel>(Lifetime.Singleton).As<IInitializable, IDisposable>();
            builder.Register<IPlayerViewModel, PlayerViewModel>(Lifetime.Singleton).As<IDisposable>();

            builder.Register<FullScreenMovementModel>(Lifetime.Singleton)
                .As<IMovementControlModel, IInitializable, IDisposable>();
            builder.Register<FullScreenMovementViewModel>(Lifetime.Singleton)
                .As<IMovementControlViewModel, IDisposable>();

            builder.Register<CameraFollowSystem>(Lifetime.Singleton);

            // State models
            builder.Register<IMenuModel, MenuModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IGameplayModel, GameplayModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IGameoverModel, GameoverModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IPauseModel, PauseModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IWinModel, WinModel>(Lifetime.Singleton).As<IInitializable>();

            // View models 
            builder.Register<IMenuViewModel, MenuViewModel>(Lifetime.Singleton).As<IInitializable, IDisposable>();
            builder.Register<IGameplayViewModel, GameplayViewModel>(Lifetime.Singleton)
                .As<IInitializable, IDisposable>();

            // State machine
            builder.Register<IStateMachine, StateMachine>(Lifetime.Singleton).As<IStartable>();

            builder.Register<MenuState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GamePlayState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GameOverState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<PauseState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<WinState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<ShelterModel>(Lifetime.Singleton).AsSelf().As<IInteractableModel, IInitializable>();

            builder.Register<IStateMachineReactiveAdapter, StateMachineReactiveAdapter>(Lifetime.Singleton);

            builder.Register<Backpack>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }
    }
}
