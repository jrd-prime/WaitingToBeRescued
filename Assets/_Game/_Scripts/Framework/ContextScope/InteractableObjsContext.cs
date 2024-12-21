using _Game._Scripts.Framework.Interacts.WorldObjs.Processors;
using _Game._Scripts.Item._Base;
using _Game._Scripts.Item.Gatherable;
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
            builder.Register<CollectProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<InteractProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<CollectWithConditionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<InteractWithConditionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<EnoughForCollectUIInfoProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<EnoughForInteractUIInfoProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<NotEnoughForCollectProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<NotEnoughForInteractProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
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
