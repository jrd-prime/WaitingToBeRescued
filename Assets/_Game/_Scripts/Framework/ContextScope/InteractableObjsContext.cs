using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
using _Game._Scripts.Framework.Interacts.WorldObjs.Processors;
using _Game._Scripts.Item._Base;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class InteractableObjsContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ShowDebugProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<CollectProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<UseProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<CollectWithConditionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<UseWithConditionProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<CollectAvailableShowUIProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<InteractAvailableShowUIProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<CollectUnavailableShowUIProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<InteractUnavaiableShowUIProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
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
