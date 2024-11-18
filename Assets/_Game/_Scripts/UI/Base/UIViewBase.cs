﻿using System;
using System.Collections.Generic;
using _Game._Scripts.UI.Interfaces;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Base
{
    public abstract class UIViewBase : MonoBehaviour, IUIView, IDisposable
    {
        protected readonly Dictionary<Button, EventCallback<ClickEvent>> CallbacksCache = new();
        protected readonly CompositeDisposable Disposables = new();


        public abstract void Show();
        public abstract void Hide();
        protected abstract void Init();
        protected abstract void InitElements();
        protected abstract void InitCallbacksCache();

        protected void RegisterCallbacks()
        {
            foreach (var (button, callback) in CallbacksCache) button.RegisterCallback(callback);
        }

        protected void UnregisterCallbacks()
        {
            foreach (var (button, callback) in CallbacksCache) button.UnregisterCallback(callback);
        }

        protected static void CheckOnNull(VisualElement element, string elementIDName, string className)
        {
            if (element == null) throw new NullReferenceException($"{elementIDName} in {className} is null");
        }

        public void Dispose()
        {
            UnregisterCallbacks();
        }

        public void Unregister()
        {
            Debug.LogWarning("unregister view callback " + name);
            UnregisterCallbacks();
        }
    }
}
