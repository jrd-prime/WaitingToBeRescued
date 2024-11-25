using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.Manager.Game;
using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.Player.Interfaces;
using _Game._Scripts.UI.Base.Model;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.GameStateMachine
{
    public abstract class GameStateBase<TUIModel, TSubStateEnum> : IGameState, IInitializable
        where TUIModel : IUIModel<TSubStateEnum> where TSubStateEnum : Enum
    {
        protected IGameManager GameManager { get; private set; }
        protected IUIManager UIManager { get; private set; }
        protected IPlayerModel PlayerModel { get; private set; }
        protected readonly Dictionary<TSubStateEnum, ISubState> SubStatesCache = new();
        protected readonly CompositeDisposable Disposables = new();

        private Action<EGameState> ChangeStateCallback { get; set; }
        protected TUIModel Model { get; private set; }

        private TSubStateEnum _subStateType;
        private ISubState _subState;
        protected ISubState CurrentSubState;

        [Inject]
        private void Construct(IGameManager gameManager, IUIManager uiController, IPlayerModel playerModel,
            TUIModel dataModel)
        {
            GameManager = gameManager;
            UIManager = uiController;
            PlayerModel = playerModel;
            Model = dataModel;
        }

        public void Initialize()
        {
            if (GameManager == null) throw new NullReferenceException("GameManager is null");
            if (UIManager == null) throw new NullReferenceException("UIManager is null");
            if (PlayerModel == null) throw new NullReferenceException("PlayerModel is null");
            if (Model == null) throw new NullReferenceException("DataModel is null");

            InitializeSubStates();
            Subscribe();

            //TODO uncomment
            //if (SubStatesCache.Count == 0) throw new Exception("SubStates is empty. You need to add substates." + this);
        }

        private void Subscribe()
        {
            InitBaseSubscribes();
            InitCustomSubscribes();
        }

        private void InitBaseSubscribes()
        {
            Model.SubState
                .Skip(1)
                .Subscribe(ChangeSubState)
                .AddTo(Disposables);
            Model.GameState
                .Skip(1)
                .Subscribe(ChangeState)
                .AddTo(Disposables);
        }

        private void ChangeSubState<TSubState>(TSubState subStateType) where TSubState : TSubStateEnum
        {
            Debug.LogWarning("<color=darkblue>[CHANGE SUB]</color> To " + subStateType + " from " + CurrentSubState);
            CurrentSubState.Exit();
            CurrentSubState = SubStatesCache[subStateType];
            SubStatesCache[subStateType].Enter();
        }

        public void Enter()
        {
            Debug.LogWarning(
                $"<color=darkblue>[ENTER BASE]</color> {GetType().Name} (SubStates: {SubStatesCache.Count} / Disp: {Disposables.Count})");
            OnBaseStateEnter();

            if (!SubStatesCache.TryGetValue(_subStateType, out _subState))
                throw new KeyNotFoundException($"SubState: {_subStateType} not found! Base state: {GetType().Name}");

            _subState.Enter();
            CurrentSubState = _subState;
        }

        public void Exit()
        {
            CurrentSubState.Exit();
            CurrentSubState = null;
            OnBaseStateExit();
            Debug.LogWarning($"<color=darkblue>[EXIT BASE]</color> {GetType().Name}");
        }

        public void SetCallback(Action<EGameState> changeStateCallback) => ChangeStateCallback = changeStateCallback;

        private void ChangeState(EGameState eGameState) => ChangeStateCallback.Invoke(eGameState);


        /// <summary>
        /// Initialize SubStates and add to cache <see cref="SubStatesCache"/>
        /// </summary>
        protected abstract void InitializeSubStates();

        protected abstract void InitCustomSubscribes();
        protected abstract void OnBaseStateEnter();
        protected abstract void OnBaseStateExit();
    }
}
