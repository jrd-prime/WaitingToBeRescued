using _Game._Scripts.Framework.Systems;
using _Game._Scripts.Player;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI.MovementControl;
using _Game._Scripts.UI.MovementControl.FullScreen;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using IMovementControlModel = _Game._Scripts.UI.MovementControl.IMovementControlModel;

namespace _Game._Scripts.Framework.ContextScope
{
    public class GameContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>GAME RUNNING CONTEXT</color>");

            builder.Register<IPlayerModel, PlayerModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IPlayerViewModel, PlayerViewModel>(Lifetime.Singleton);

            builder.Register<FullScreenMovementModel>(Lifetime.Singleton).As<IFullScreenMovementModel>()
                .As<IMovementControlModel>();
            builder.Register<FullScreenMovementViewModel>(Lifetime.Singleton).As<IFullScreenMovementViewModel>()
                .As<IMovementControlViewModel>();

            builder.Register<CameraFollowSystem>(Lifetime.Singleton);
        }
    }
}
