using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.ContextScope;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Framework.Manager.UI.Viewer;
using _Game._Scripts.UI.Base.View;
using _Game._Scripts.UIOLD;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace _Game._Scripts.Framework.Manager.UI
{
    public abstract class UIManagerBase : MonoBehaviour, IUIManager
    {
        [Header("Viewer"), RequiredField, SerializeField]
        protected UIViewer viewer;

        private readonly Dictionary<GameStateType, ViewBase> _views = new();

        private ISettingsManager _settingsManager;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            Debug.LogWarning("Construct UIControllerBase");
            _settingsManager = resolver.Resolve<ISettingsManager>();
        }

        private void Awake()
        {
            Debug.LogWarning("UIControllerBase awake");
            if (_settingsManager == null) throw new NullReferenceException("SettingsManager is null.");

            var uiContext = FindFirstObjectByType<UIContext>() ??
                            throw new NullReferenceException("UIContext not found");

            var views = GetComponentsInChildren<ViewBase>();

            if (views.Length == 0 || views == null) throw new Exception("Views not found");

            foreach (var view in views)
            {
                uiContext.Container.Inject(view);
                _views.TryAdd(view.viewForGameStateType, view);
            }
        }

        public void ShowView(GameStateType gameStateType, bool toSafe = false)
        {
            Debug.LogWarning("Show view: " + gameStateType);
            if (!_views.TryGetValue(gameStateType, out var view))
                throw new KeyNotFoundException("View not found for game state: " + gameStateType);
            var visual = view.GetTemplateContainer();
            viewer.ShowView(visual, view.safeZone);
        }

        public void HideView(GameStateType gameStateType)
        {
            viewer.HideView();
        }

        public abstract void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);
    }

    [Serializable]
    public struct MenuViewData
    {
        public GameStateType menuForType;
        public AssetReferenceGameObject menuViewPrefab;
    }
}
