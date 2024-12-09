using _Game._Scripts.Item;
using _Game._Scripts.Item.Gatherable;
using _Game._Scripts.Item.Pickable;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class InteractableObjsContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PickableItemSystem>(Lifetime.Singleton).AsSelf();
            builder.Register<GatherableItemSystem>(Lifetime.Singleton).AsSelf();
            builder.RegisterComponentInHierarchy<InteractableItemBase>();
        }
    }
}
