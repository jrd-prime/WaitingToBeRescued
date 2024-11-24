﻿using System;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class JSubViewBase : MonoBehaviour
    {
        [SerializeField] protected string headerNameId;
        [SerializeField] protected VisualTreeAsset template;
        [SerializeField] public bool inSafeZone;

        protected TemplateContainer Template;
        protected VisualElement ContentContainer;
        protected bool IsInitialized;

        protected readonly Dictionary<Button, EventCallback<ClickEvent>> CallbacksCache = new();
        protected readonly CompositeDisposable Disposables = new();

        /// <summary>
        /// Register initialized callbacks
        /// </summary>
        protected void RegisterCallbacks()
        {
            if (CallbacksCache.Count == 0)
            {
                Debug.LogWarning("No callbacks to register. " + name);
                return;
            }

            foreach (var callback in CallbacksCache)
                callback.Key.RegisterCallback(callback.Value);
        }

        /// <summary>
        /// Unregister initialized callbacks
        /// </summary>
        protected void UnregisterCallbacks()
        {
            Debug.LogWarning("unreg callbacks " + name);
            if (CallbacksCache.Count == 0)
            {
                Debug.LogWarning("No callbacks to unregister. " + name);
                return;
            }

            foreach (var callback in CallbacksCache)
                callback.Key.UnregisterCallback(callback.Value);
        }

        /// <summary>
        /// Find and initialize UI elements
        /// </summary>
        protected abstract void InitializeView();

        /// <summary>
        /// Localize
        /// </summary>
        protected abstract void Localize();

        /// <summary>
        /// Add callbacks to UI elements
        /// </summary>
        protected abstract void InitializeCallbacks();

        public TemplateContainer GetTemplate()
        {
            if (!IsInitialized) throw new Exception("View is not initialized. " + name);

            return Template ?? throw new NullReferenceException("Template is null. " + name);
        }
    }
}
