using _Game._Scripts.Item;
using _Game._Scripts.Item._Base;
using _Game._Scripts.Item.Gatherable;
using _Game._Scripts.Item.Pickable;
using UnityEngine;
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
        }

        private void Start()
        {
            var items = FindObjectsByType<InteractableItemBase>(FindObjectsSortMode.None);
            foreach (var item in items) Container.Inject(item);
            Debug.Log("InteractableItemBase objects found and injected: " + items.Length);
        }
    }
}
