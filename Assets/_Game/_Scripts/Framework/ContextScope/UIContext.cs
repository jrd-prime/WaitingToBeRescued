using _Game._Scripts.UI.Base;
using _Game._Scripts.UI.MainMenu;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class UIContext : LifetimeScope
    {
        [SerializeField] private UIViewBase menu;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>UI CONTEXT</color>");

            // Models
            builder.Register<IMenuUIModel, MenuUIModel>(Lifetime.Singleton).AsImplementedInterfaces();
            // ViewModels
            builder.Register<MenuUIViewModel>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            // Views
            builder.RegisterComponent(menu as MenuUIView).AsSelf();
        }
    }
}
