using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.UI.Menus.Main;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class UIContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>UI context</color>");
            // Menu buttons handler
            builder.Register<IMenuButtonsHandler, MenuButtonsHandler>(Lifetime.Singleton);

            // Main menu
            builder.Register<IMainMenuViewModel, MainMenuUIViewModel>(Lifetime.Singleton).As<IInitializable>();
            builder.Register<IMainMenuModel, MainMenuModel>(Lifetime.Singleton).As<IInitializable>();
        }
    }
}
