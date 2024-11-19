using _Game._Scripts.Bootstrap;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.UI.Bootstrap;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class BoostrapContext : LifetimeScope
    {
        [RequiredField, SerializeField] private LoadingScreenView loadingScreenView;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>Bootstrap context</color>");

            builder.Register<ILoadingScreenModel, LoadingScreenModel>(Lifetime.Singleton);
            builder.Register<ILoadingScreenViewModel, LoadingScreenViewModel>(Lifetime.Singleton);

            builder.RegisterComponent(loadingScreenView);
            builder.Register<ILoader, Loader>(Lifetime.Singleton);

            builder.RegisterEntryPoint<AppStarter>();
        }
    }
}
