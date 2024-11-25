using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data;
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
        private bool _isViewsInitialized;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
            _settingsManager = resolver.Resolve<ISettingsManager>();
        }

        public void Initialize()
        {
            foreach (var view in stateViews)
            {
                _resolver.Inject(view.viewHolder);
                _views.TryAdd(view.uiForState, view.viewHolder);
            }

            if (stateViews.Count == 0) throw new Exception("Views not found!");
            if (Enum.GetNames(typeof(EGameState)).Length != stateViews.Count)
                Debug.LogError("View count is not equal to game state count");

            _isViewsInitialized = true;
        }

        private void Start()
        {
            if (_settingsManager == null) throw new NullReferenceException("SettingsManager is null.");
        }

        public void ShowView(EGameState eGameState, Enum subState)
        {
            Debug.LogWarning("Show view: " + eGameState + ", " + subState + " / " + _isViewsInitialized);
            if (!_isViewsInitialized) throw new NullReferenceException($"Views not initialized. {name}");

            Debug.LogWarning("Show view: " + eGameState + ", " + subState + " / " + _isViewsInitialized);
            if (!_views.TryGetValue(eGameState, out var viewBase))
                throw new KeyNotFoundException($"View not found for state:  {eGameState}. {name}");

            Debug.LogWarning("Show view: " + eGameState + ", " + subState + " / " + _isViewsInitialized);
            SubViewDto subViewDto = viewBase.GetSubViewDto(subState);

            Debug.LogWarning("Show view: " + eGameState + ", " + subState + " / " + _isViewsInitialized);

            viewer.ShowView(subViewDto.Template, subViewDto.InSafeZone);
        }

        public void HideView(EGameState eGameState, Enum subState)
        {
            viewer.HideView();
        }

        public abstract void ShowPopUpAsync(string clickTimesToExit, int doubleClickDelay);
    }
}
