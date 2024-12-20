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
            builder.Register<GatherableObjSystem>(Lifetime.Singleton).AsSelf();

            builder.Register<ShowDebugProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<CollectionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<InteractionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<ConditionCollectionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<ConditionInteractionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<ShowCharHUDInfoProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
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
