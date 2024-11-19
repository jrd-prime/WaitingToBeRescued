using System;
using System.Collections.Generic;
using System.Threading;
using _Game._Scripts.Framework.Helpers.Attributes;
using _Game._Scripts.UI.Base;
using _Game._Scripts.UI.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game._Scripts.UI
{
    // TODO : consider safe areas for the user interface
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<ToolkitView> toolkitViews;

        [RequiredField, SerializeField] private UIToolkitViewer toolkitViewer;

        // [SerializeField] private UIViewBase menu;
        // [SerializeField] private UIViewBase game;
        // [SerializeField] private UIViewBase pause;
        // [SerializeField] private UIViewBase gameOver;
        // [SerializeField] private UIViewBase settings;
        // [SerializeField] private UIViewBase win;
        [RequiredField, SerializeField] private PopUpView popUp;

        // [SerializeField] private GameplayUIView gameplayUIView;

        private readonly Dictionary<GameStateType, UIViewBase> _views = new();
        private CancellationTokenSource _cts;

        private void Awake()
        {
            var viewsCount = toolkitViews.Count;
            var typesCount = Enum.GetNames(typeof(GameStateType)).Length;
            if (viewsCount != typesCount)
                Debug.LogWarning($"Not all views are set! /// Set: {viewsCount} / Total: {typesCount}");

            if (toolkitViewer == null) throw new NullReferenceException("ToolkitViewer is null.");

            // throw new Exception(
            //     $"Not all views are set! /// Set: {viewsCount} / Total: {Enum.GetNames(typeof(StateType)).Length}");
            // InitializeView(StateType.Menu, menu);
            // // InitializeView(StateType.Game, game);
            // InitializeView(StateType.Game, gameplayUIView);
            // InitializeView(StateType.Pause, pause);
            // InitializeView(StateType.GameOver, gameOver);
            // InitializeView(StateType.Settings, settings);
            // InitializeView(StateType.Win, win);

            // foreach (var toolkitView in toolkitViews) InitializeView(toolkitView.viewForState, toolkitView.view);
        }

        public void ShowView(GameStateType menuForGameStateType)
        {
            if (!_views.TryGetValue(menuForGameStateType, out var toolkitView))
                throw new KeyNotFoundException($"View for state: {menuForGameStateType} not found!");

            // var a = ((IUIView)toolkitView).GetView();

            // Debug.LogWarning(a + $" /// {toolkitView.name}  /// " + menuForStateType);

            // toolkitViewer.ShowView(a);
        }

        public void HideView(GameStateType menuForGameStateType)
        {
            var toolkitView = _views[menuForGameStateType];
            toolkitView.Unregister();
        }

        public async void ShowPopUpAsync(string text, int duration = 3000)
        {
            if (_cts != null)
            {
                _cts.Cancel();
                popUp.Hide();
            }

            _cts = new CancellationTokenSource();
            popUp.Show(text);

            try
            {
                await UniTask.Delay(duration, cancellationToken: _cts.Token);
            }
            catch (OperationCanceledException)
            {
                return;
            }

            popUp.Hide();
            _cts = null;
        }

        // private void InitializeView(StateType type, UIView<> uiView)
        // {
        //     if (uiView == null) throw new NullReferenceException($"View of type {type} not set to UIManager prefab!");
        //     // uiView.Hide();
        //     _views.Add(type, uiView);
        // }
    }

    [Serializable]
    public struct ToolkitView
    {
        [FormerlySerializedAs("viewForState")] public GameStateType viewForGameState;
        // public UIView<> view;
    }
}
