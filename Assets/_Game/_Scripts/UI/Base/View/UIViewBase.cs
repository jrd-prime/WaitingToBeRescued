using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using R3;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class UIViewBase : MonoBehaviour, IUIView
    {
        [SerializeField] protected string headerNameId;
        [FormerlySerializedAs("viewForEGameStateType")] [FormerlySerializedAs("viewForGameStateType")] [SerializeField] public EGameState viewForEGameState = EGameState.NotSet;
        [RequiredField, SerializeField] protected VisualTreeAsset viewTemplate;
        [SerializeField] public bool safeZone;
        protected VisualElement ContentContainer;

        protected readonly CompositeDisposable Disposables = new();
        protected TemplateContainer _template;
        protected bool _isInitialized;

        protected readonly Dictionary<Button, EventCallback<ClickEvent>> CallbacksCache = new();
        protected abstract void InitializeView();
        protected abstract void InitializeCallbacks();

        public TemplateContainer GetTemplateContainer()
        {
            if (!_isInitialized)
                throw new Exception("View is not initialized. " + name); //TODO mb call InitializeView??
            return _template;
        }
    }
}
