﻿using _Game._Scripts.Framework.Interacts.Processors;
using _Game._Scripts.Framework.Interacts.WorldObjs.Behaviour._Base;
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

            builder.Register<CheckInteractConditionsProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<CollectProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<UseProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            builder.Register<CollectUIProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<UseUIProcessor>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
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
