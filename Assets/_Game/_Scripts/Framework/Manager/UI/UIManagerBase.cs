using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.Settings;
using _Game._Scripts.Framework.Manager.UI.Viewer;
using _Game._Scripts.UI.Base.View;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.Manager.UI
{
    public abstract class UIManagerBase : MonoBehaviour, IUIManager
    {
        [Header("Viewer"), RequiredField, SerializeField]
        protected UIViewer viewer;

        private readonly Dictionary<EGameState, UIViewBase> _views = new();

        [SerializeField] protected List<StateViewData> stateViews = new();

        private ISettingsManager _settingsManager;
        private IObjectResolver _resolver;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
            _settingsManager = resolver.Resolve<ISettingsManager>();
        }

        private void Start()
        {
            Debug.LogWarning("start " + name);
            if (_settingsManager == null) throw new NullReferenceException("SettingsManager is null.");

            if (stateViews.Count == 0) throw new Exception("Views not found!");
            if (Enum.GetNames(typeof(EGameState)).Length != stateViews.Count)
                Debug.LogWarning("View count is not equal to game state count");
        }

        public void ShowView(EGameState eGameState, Enum subState, bool toSafe = false)
        {
            Debug.LogWarning("Show view: " + eGameState + ", " + subState);
            if (!_views.TryGetValue(eGameState, out UIViewBase view))
                throw new KeyNotFoundException("View not found for game state: " + eGameState);
            var subView = view.GetSubView(subState);

            var visual = subView.GetTemplate();

            Debug.LogWarning("show view: " + subView.name);
            viewer.ShowView(visual, subView.inSafeZone);
        }

        public void HideView(EGameState eGameState, Enum subState)
        {
            viewer.HideView();
        }

        public abstract void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);

        public void Initialize()
        {
            foreach (var view in stateViews)
            {
                Debug.LogWarning("INJECT = " + this);
                _resolver.Inject(view.viewHolder);
                _views.TryAdd(view.uiForState, view.viewHolder);
            }
        }
    }

    [Serializable]
    public struct StateViewData
    {
        public EGameState uiForState;
        public UIViewBase viewHolder;
    }
}
