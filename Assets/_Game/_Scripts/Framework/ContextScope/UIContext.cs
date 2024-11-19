using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.NewUI;
using _Game._Scripts.NewUI.Menus.Main;
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

            builder.Register<IMainMenuViewModel, MainMenuViewModel>(Lifetime.Singleton);
        }
    }
}
