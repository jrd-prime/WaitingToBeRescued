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

        protected Action<EGameState> ChangeStateCallback { get; private set; }
        protected TUIModel Model { get; private set; }

        private TSubStateEnum _defaultSubStateType;
        private ISubState _defaultSubState;
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
//TODO uncomm
            // if (SubStates.Count == 0) throw new Exception("SubStates is empty. You need to add substates." + this);
            // if (_defaultSubStateType == null)
            //     throw new Exception("DefaultSubState is  not set. Use SetDefaultSubState()" + this);
        }

        protected void ChangeSubState<TSubState>(TSubState subStateType) where TSubState : TSubStateEnum
        {
            Debug.LogWarning("Change sub state to " + subStateType + " from " + CurrentSubState);
            CurrentSubState.Exit();
            CurrentSubState = SubStatesCache[subStateType];
            SubStatesCache[subStateType].Enter();
        }

        public void Enter()
        {
            SubscribeToModel();
            Debug.LogWarning("subscribe to model completed in " + GetType().Name);
            Debug.LogWarning(
                $"--- {GetType().Name} enter. (DefaultSubStateType: {_defaultSubStateType} ) (SubStates count: {SubStatesCache.Count})");
            OnMainStateEnter();


            if (!SubStatesCache.TryGetValue(_defaultSubStateType, out _defaultSubState))
                throw new KeyNotFoundException(
                    $"SubState: {_defaultSubStateType} not found! Base state: {GetType().Name}");

            Debug.LogWarning("Default sub state: " + _defaultSubState);

            _defaultSubState.Enter();
            if (CurrentSubState != null) Debug.LogWarning($"------ {CurrentSubState?.GetType().Name} enter");

            CurrentSubState = _defaultSubState;
        }

        public void Exit()
        {
            CurrentSubState.Exit();
            Debug.LogWarning($"------ {CurrentSubState.GetType().Name} exit");
            CurrentSubState = null;
            Debug.LogWarning($"--- {GetType().Name} exit");
            OnMainStateExit();
            Disposables.Dispose();
        }

        public void SetCallback(Action<EGameState> changeStateCallback) => ChangeStateCallback = changeStateCallback;


        /// <summary>
        /// Initialize SubStates and add to cache <see cref="SubStatesCache"/>
        /// </summary>
        protected abstract void InitializeSubStates();

        protected abstract void SubscribeToModel();
        protected abstract void OnMainStateEnter();
        protected abstract void OnMainStateExit();
    }
}
