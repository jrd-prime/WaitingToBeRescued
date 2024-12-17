using _Game._Scripts.Framework.Interact.Character.Processors;
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
            builder.Register<PickableObjSystem>(Lifetime.Singleton).AsSelf();
            builder.Register<GatherableObjSystem>(Lifetime.Singleton).AsSelf();

            builder.Register<ShowDebugProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<PickUpProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<GatherProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }

        private void Start()
        {
            Debug.Log("Injecting interactable items");
            var items = FindObjectsByType<InteractableObjBase>(FindObjectsSortMode.None);
            foreach (var item in items) Container.Inject(item);
            Debug.Log("InteractableItemBase objects found and injected: " + items.Length);
        }
    }
}
